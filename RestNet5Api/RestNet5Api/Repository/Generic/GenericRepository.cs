using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestNet5Api.Model.Base;
using RestNet5Api.Model.Context;

namespace RestNet5Api.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            try {
                dataSet.Add(entity);
                _context.SaveChanges();
            } catch(Exception ex) {
                throw ex;
            }

            return entity;
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(e => e.Id == id);

            if(result != null){
                try {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                } catch(Exception ex) {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(e => e.Id == id);
        }

        public System.Collections.Generic.List<T> FindAll()
        {
            return dataSet.ToList();;
        }

        public T FindByID(long id)
        {
            return dataSet.SingleOrDefault(e => e.Id == id);;
        }

        public T Update(T entity)
        {
            if(!Exists(entity.Id))
                return null;

            var result = dataSet.SingleOrDefault(e => e.Id == entity.Id);

            if(result != null){
                try {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return entity;
                } catch(Exception ex) {
                    throw ex;
                }
            } else {
                return null;
            }

            
        }
    }
}