using System;
using System.Collections.Generic;
using System.Threading;
using RestNet5Api.Model;

namespace RestNet5Api.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++){
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

     

        public Person FindByID(long id)
        {
            return new Person(){
                Id = 1,
                FirstName = "Eduardo",
                LastName = "Luna",
                Address = "São Paulo - SP",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
           return person;
        }

       private Person MockPerson(int i)
        {
            return new Person(){
                Id = IncrementAndGet(),
                FirstName = "PFirst Name " + i,
                LastName = "PLast Name " + i,
                Address = "YEAH " + i,
                Gender = i % 2 == 0 ? "Masculino" : "Feminino"
            };
        }

        private long IncrementAndGet()
        {
           return Interlocked.Increment(ref count);
        }
    }
}