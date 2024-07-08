using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    internal class Library
    {
        public List<Book> Lib{ get; set; }

        public Library(params  Book[]lib)
        {
            Lib = lib.ToList();
        }
    }
}
