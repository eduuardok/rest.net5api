using System;
using System.Collections.Generic;
using System.Linq;
using RestNet5Api.Model;
using RestNet5Api.Model.Context;

namespace RestNet5Api.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try {
                _context.Add(person);
                _context.SaveChanges();
            } catch(Exception ex) {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id == id);

            if(result != null){
                try {
                    _context.Remove(result);
                    _context.SaveChanges();
                } catch(Exception ex) {
                    throw ex;
                }
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {

            if(!Exists(person.Id))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);

            if(result != null){
                try {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                } catch(Exception ex) {
                    throw ex;
                }
            }

            return person;
        }
        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}