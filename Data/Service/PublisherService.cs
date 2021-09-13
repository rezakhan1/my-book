using my_book.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Service
{
    public class PublisherService
    {
       readonly AppDBContext _appDBContext;
        public PublisherService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public List<Publisher> showAllPublisher(string sortBy,string searchText)
        {
            var result = _appDBContext.Publishers.OrderBy(x => x.Name).ToList();
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "sortby_Name":
                         result = _appDBContext.Publishers.OrderByDescending(x => x.Name).ToList();
                        break;
                    default:
                        break;

                } 
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                result = _appDBContext.Publishers.Where(x => x.Name.Contains(searchText,StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            return result;
        }
        public Publisher AddPublisher(PublisherVM _publisher  )
        {
            Publisher publisher = new Publisher()
            {
                Name = _publisher.Name
            };
            _appDBContext.Add(publisher);
            _appDBContext.SaveChanges();

            return publisher;
        }

        public Publisher GetPublisher(int Id)
        {
            var res = _appDBContext.Publishers.FirstOrDefault(x => x.Id == Id);

            return res;

        }
        public PublisherWithBookAndAuthorVM getPublisherById(int id)
        {

            var reslut = _appDBContext.Publishers.Where(x=>x.Id==id).Select(publisher => new PublisherWithBookAndAuthorVM()
            {
                Name = publisher.Name,
                bookAuthorVMs = publisher.Books.Select(books => new BookAuthorVM()
                {
                    Book = books.Title,
                    AuthorName = books.Author_Books.Select(x => x.Author.Name).ToList()
                }).ToList()

            }).SingleOrDefault(); 
            if(reslut != null)
            {

            }
            else
            {
                throw new Exception($"This {id} is not found");
            }
            return reslut;
        }
    }
}
