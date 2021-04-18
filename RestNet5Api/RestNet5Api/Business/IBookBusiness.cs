using System.Collections.Generic;
using RestNet5Api.Data.VO;

namespace RestNet5Api.Business
{
    public interface IBookBusiness
    {
         BookVO Create(BookVO book);
         BookVO FindByID(long id);
         BookVO Update(BookVO book);
         void Delete(long id);
         List<BookVO> FindAll();
    }
}