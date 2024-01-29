using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            this.Books.Sort();
            for (int i = 0; i < this.Books.Count; i++)
            {
                yield return this.Books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {

            public List<Book> Books { get; set; }
            private int position = -1;

            public LibraryIterator(List<Book> books)
            {
                this.Books= books;
                Reset();
            }
            public Book Current => this.Books[position];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.position++;
                return position <= Books.Count;
            }

            public void Reset()
            {
                this.position = -1;
            }
        }
    }
}
