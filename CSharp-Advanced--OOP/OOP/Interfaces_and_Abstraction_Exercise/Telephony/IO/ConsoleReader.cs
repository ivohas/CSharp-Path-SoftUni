namespace Telephony.IO
{
    using Interfaces;
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
