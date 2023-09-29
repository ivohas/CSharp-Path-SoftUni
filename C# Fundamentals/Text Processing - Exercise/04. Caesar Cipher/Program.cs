using System;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawInput = Console.ReadLine();

            char[] CaesarCipher = new char[rawInput.Length];

            for (int i = 0; i < rawInput.Length; i++)
            {
                CaesarCipher[i] = (char)(rawInput[i] + 3);
            }

            Console.WriteLine(CaesarCipher);
        }
    }
}
