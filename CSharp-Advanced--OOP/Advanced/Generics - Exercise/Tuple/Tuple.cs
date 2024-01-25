using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstElement, TSecond secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }

        public TFirst FirstElement { get; private set; }
        public TSecond SecondElement { get; private set; }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement}";
        }
    }
}
