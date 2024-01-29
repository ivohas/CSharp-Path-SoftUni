using IteratorsAndComparators;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookComparer
{
    public class Comparer : Comparer<Book>
    {
        public override int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
                result = y.Year.CompareTo(x.Year);
            return result;

        }
    }
}
