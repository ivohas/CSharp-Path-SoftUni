using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;
        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            var lastElement = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return lastElement;
        }
    }
}
