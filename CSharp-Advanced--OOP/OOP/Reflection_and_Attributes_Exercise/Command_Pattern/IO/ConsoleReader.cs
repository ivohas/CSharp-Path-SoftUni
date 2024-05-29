using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
