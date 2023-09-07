using System;

namespace _05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string decryptedText = string.Empty;

            for (int i = 0; i < n; i++)
            {
                decryptedText += (char) (char.Parse(Console.ReadLine()) + key);
            }
            Console.WriteLine(decryptedText);
        }
    }
}
