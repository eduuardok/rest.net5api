using System.Collections.Generic;
using RestNet5Api.Data.VO;

namespace RestNet5Api.Business
{
    public interface IPersonBusiness
    {
         PersonVO Create(PersonVO person);
         PersonVO FindByID(long id);
         PersonVO Update(PersonVO person);
         void Delete(long id);
         List<PersonVO> FindAll();
    }
}