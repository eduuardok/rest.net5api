using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestNet5Api.Model.Context;
using RestNet5Api.Business;
using RestNet5Api.Business.Implementations;
using RestNet5Api.Repository;
using Serilog;
using MySqlConnector;
using System.Collections.Generic;
using RestNet5Api.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestNet5Api.Hypermedia.Filters;
using RestNet5Api.Hypermedia.Enricher;

namespace RestNet5Api
{
    public class Startup
    {
        public IWebHostEnvironment Environment {get;}
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // if(Environment.IsDevelopment()){
            //     MigrateDatabase(Configuration.GetConnectionString("MySQLConnection"));
            // }
                

            services.AddControllers();
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<MySqlContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQLConnection"), new MySqlServerVersion(new Version(5,7))));
            
            services.AddMvc(options => {
               options.RespectBrowserAcceptHeader = true;
               options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml")); 
               options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());

            services.AddSingleton(filterOptions);

            services.AddApiVersioning();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestNet5Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestNet5Api v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
        private void MigrateDatabase(string connection)
        {
            try {
                var evolveConnection = new MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg)) {
                    Locations = new List<string> {"db/migrations", "db/dataset"},
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            } catch (Exception ex){
                Log.Error("Database migration failed: " + ex);
            }
        }
    }
    
}
