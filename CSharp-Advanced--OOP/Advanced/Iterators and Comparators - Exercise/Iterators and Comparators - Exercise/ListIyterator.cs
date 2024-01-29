using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListIyterator<T>
    {
        private List<T> collection;
        private int currIndex;

        public ListIyterator(params T[] data)
        {
            collection = new List<T>(data);
            currIndex = 0;
        }

        public bool HasNext() => currIndex < collection.Count - 1;

        public bool Move()
        {
            bool canMove =  HasNext();
            if (canMove)
                currIndex++;
            return canMove;
        }

        public void Print()
        {
            if (collection.Count == 0)
                throw new ArgumentException("Invalid Operation!");

            Console.WriteLine(collection[currIndex]);
        }
    }
}
