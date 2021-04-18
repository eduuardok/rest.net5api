using System.Collections.Generic;
using RestNet5Api.Model;
using RestNet5Api.Model.Base;

namespace RestNet5Api.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
         T Create(T entity);
         T FindByID(long id);
         T Update(T entity);
         void Delete(long id);
         List<T> FindAll();
         bool Exists(long id);
    }
}