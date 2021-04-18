using System.Collections.Generic;
using RestNet5Api.Model;

namespace RestNet5Api.Business
{
    public interface IBookBusiness
    {
         Book Create(Book book);
         Book FindByID(long id);
         Book Update(Book book);
         void Delete(long id);
         List<Book> FindAll();
    }
}