using my_book.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Service
{
    public class AuthorService
    {
        readonly AppDBContext _appDBContext;

        public AuthorService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            Author author1 = new Author()
            {
                Name = author.Name
           };
            _appDBContext.Add(author1);
            _appDBContext.SaveChanges();

          
        }
        public AuthorVM getAuthorBook(int id)
        {
            var author = _appDBContext.Authors.Where(n=>n.Id==id).Select(a => new AuthorVM()
            {
                Name = a.Name,
                Books = a.Author_Books.Select(x => x.Book.Title).ToList()
            }).SingleOrDefault() ;
          return  author;
        }

    }
}
