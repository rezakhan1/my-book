using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Model
{
    public class AuthorVM
    {
         

        public string Name { get; set; }

        public List<string> Books { get; set; }
    }
}
