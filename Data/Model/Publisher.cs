using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation

        public List<Book> Books { get; set; }

    }
}
