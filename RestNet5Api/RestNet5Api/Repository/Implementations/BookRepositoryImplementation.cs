using System;
using System.Collections.Generic;
using System.Linq;
using RestNet5Api.Model;
using RestNet5Api.Model.Context;

namespace RestNet5Api.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySqlContext _context;

        public BookRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try {
                _context.Add(book);
                _context.SaveChanges();
            } catch(Exception ex) {
                throw ex;
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id == id);

            if(result != null){
                try {
                    _context.Remove(result);
                    _context.SaveChanges();
                } catch(Exception ex) {
                    throw ex;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id == id);
        }

        public Book Update(Book book)
        {

            if(!Exists(book.Id))
                return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id == book.Id);

            if(result != null){
                try {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                } catch(Exception ex) {
                    throw ex;
                }
            }

            return book;
        }
        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id == id);
        }
    }
}