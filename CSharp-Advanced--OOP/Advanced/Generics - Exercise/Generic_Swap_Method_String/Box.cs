using System;
using System.Collections.Generic;
using System.Text;

namespace Swap
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elements)
        {
            Elements = elements;
        }
        public T Element { get; set; }
        public List<T> Elements { get; }

        public void Swap(List<T> elements, int index1, int index2)
        {
            T firstEl = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = firstEl;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
