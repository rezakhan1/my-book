using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Model
{
    public class PublisherVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

         

    }
    public class PublisherWithBookAndAuthorVM
    {
       
        public string Name { get; set; }

        public List<BookAuthorVM> bookAuthorVMs { get; set; }

    }
    public class BookAuthorVM
    {
        public string Book { get; set; }
        public List<string> AuthorName { get; set; }
    }
}

