using System;

namespace Generic_Scale
{
    internal class StartUp
    {
        static void Main()
        {
            bool equals = EqualityScale<int>.AreEqual(1, 2);

            Console.WriteLine(equals);
        }
    }
}
