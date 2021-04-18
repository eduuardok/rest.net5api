using System.Collections.Generic;
using System.Linq;
using RestNet5Api.Data.Converter.Contract;
using RestNet5Api.Data.VO;
using RestNet5Api.Model;

namespace RestNet5Api.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if(origin == null)
                return null;
            
            return new BookVO(){
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
                AuthorAndTitle = origin.Author + ": " + origin.Title
            };
        }

        public Book Parse(BookVO origin)
        {
            if(origin == null)
                return null;
            
            return new Book(){
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if(origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if(origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}