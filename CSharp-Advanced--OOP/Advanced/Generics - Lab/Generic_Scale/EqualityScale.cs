using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Scale
{
    public class EqualityScale<T>
    {
        public static bool AreEqual(T left, T right)
        {
            return left.Equals(right);
        }
    }
}
