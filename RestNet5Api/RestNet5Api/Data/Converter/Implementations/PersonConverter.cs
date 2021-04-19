using System.Collections.Generic;
using System.Linq;
using RestNet5Api.Data.Converter.Contract;
using RestNet5Api.Data.VO;
using RestNet5Api.Model;

namespace RestNet5Api.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if(origin == null)
                return null;
            
            return new PersonVO(){
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if(origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public Person Parse(PersonVO origin)
        {
            if(origin == null)
                return null;
            
            return new Person(){
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if(origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}