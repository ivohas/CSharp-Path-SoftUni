using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    internal class Library
    {
        public List<Book> lib { get; set; }

        public Library( params Book[] lib)
        {
            this.lib = lib.ToList();
        }
    }
}
