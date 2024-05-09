using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public StackOfStrings(IEnumerable<string> collection)
        {
            this.AddRange(collection);
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange()
        {
            return new Stack<string>(this);
        }
        private void AddRange(IEnumerable<string> collection)
        {
            foreach (var el in collection)
            {
                this.Push(el);
            }
        }
    }
}
