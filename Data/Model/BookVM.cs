using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Model
{
    public class BookVM
    {
      

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
        public List<int> AuthoIds { get; set; }

    }
    public class BookWithAuthorVM
    {
     
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
 
        public string Publisher { get; set; }

        public List<string> Authors { get; set; }
    }
}
