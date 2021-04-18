using System.Collections.Generic;
using RestNet5Api.Model;

namespace RestNet5Api.Repository
{
    public interface IBookRepository
    {
         Book Create(Book book);
         Book FindByID(long id);
         Book Update(Book book);
         void Delete(long id);
         List<Book> FindAll();
         bool Exists(long id);
    }
}