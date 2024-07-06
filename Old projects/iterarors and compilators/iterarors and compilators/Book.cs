using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    internal class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public  List<string> Autors { get; set; }

        public Book(string title, int year, params string[] autors)
        {
            Title = title;
            Year = year;
            Autors = autors.ToList();
        }
    }
}
