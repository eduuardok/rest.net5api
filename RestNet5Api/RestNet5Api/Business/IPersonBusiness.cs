using System.Collections.Generic;
using RestNet5Api.Model;

namespace RestNet5Api.Business
{
    public interface IPersonBusiness
    {
         Person Create(Person person);
         Person FindByID(long id);
         Person Update(Person person);
         void Delete(long id);
         List<Person> FindAll();
    }
}