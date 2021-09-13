using my_book.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Service
{
    public class BookService
    {
        private AppDBContext _appDBContext;
        public BookService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }    

        public void AddBookWithAuthor(BookVM book)
        {
            Book _book = new Book()
            {
                Description = book.Description,
                Title = book.Title,
                IsRead = book.IsRead,
                Rate = book.Rate,
                Genre = book.Genre,             
                CoverUrl = book.CoverUrl,
                PublisherId=book.PublisherId
                
            };
            _appDBContext.Add(_book);
            _appDBContext.SaveChanges();

            foreach (var authorId in book.AuthoIds)
            {
                var author = new Author_Book()
                { 
                    AuthorId = authorId,
                    BookId = _book.Id
                };
                _appDBContext.Add(author);
                _appDBContext.SaveChanges();
            }
        }
        public List<Book> getListOfBooks() => _appDBContext.Books.ToList();

        public BookWithAuthorVM getBookWithAuthor(int id)
        {
            var book = _appDBContext.Books.Where(n => n.Id == id).Select(book => new BookWithAuthorVM()
            {
                Description = book.Description,
                Title = book.Title,
                IsRead = book.IsRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Publisher = book.Publisher.Name,
                Authors = book.Author_Books.Select(x => x.Author.Name).ToList()

            }).SingleOrDefault();

            return book;
        }

        public Book upDateBook(int bookId, Book _book)
        {
            Book book = _appDBContext.Books.FirstOrDefault(x => x.Id == bookId);

            if(book != null)
            {
                book.Description = _book.Description;
                book.Title = _book.Title;
                book.IsRead = _book.IsRead;
                book.Rate = _book.Rate;
                book.Genre = _book.Genre;
               
                book.CoverUrl = _book.CoverUrl;
            }
            _appDBContext.SaveChanges();
            return book;
        }

        public void deleteBook(int bookId)
        {
            Book book = _appDBContext.Books.FirstOrDefault(x => x.Id == bookId);

            if(book != null)
            {
                _appDBContext.Books.Remove(book);

                _appDBContext.SaveChanges();
            }
        }
    }
}
