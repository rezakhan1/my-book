using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Model
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        //Navigation
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Author_Book> Author_Books { get; set; }

    }
}
