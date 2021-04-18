using System.Collections.Generic;
using RestNet5Api.Model;

namespace RestNet5Api.Repository
{
    public interface IPersonRepository
    {
         Person Create(Person person);
         Person FindByID(long id);
         Person Update(Person person);
         void Delete(long id);
         List<Person> FindAll();
         bool Exists(long id);
    }
}