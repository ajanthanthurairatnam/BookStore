using System.Collections.Generic;

namespace BookStore.Core
{
    public interface IBookServices
    {
        public List<Book> GetBooks();
        Book GetBook(string id);
        Book AddBook(Book book);
        void DeleteBook(string id);
        Book UpdateBook(Book book);
    }
}
