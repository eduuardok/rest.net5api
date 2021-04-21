using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestNet5Api.Data.VO;
using RestNet5Api.Hypermedia.Constants;

namespace RestNet5Api.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "v1/pessoa";
            string link = getLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink() {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet

            });
            content.Links.Add(new HyperMediaLink() {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost

            });
            content.Links.Add(new HyperMediaLink() {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut

            });
            content.Links.Add(new HyperMediaLink() {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"

            });
            return null;
        }

        private string getLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock){
                var url = new {controller = path, id = id};
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").Replace("?version=1", "").ToString();
            };
        }
    }
}