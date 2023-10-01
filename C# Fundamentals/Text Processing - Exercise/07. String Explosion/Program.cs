using System;
using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            StringBuilder outputText = new StringBuilder();
            int bombPower = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                char currChar = inputString[i];

                if (currChar == '>')
                {
                    int currBombPower = GetIntValueOfCharacter(inputString[i + 1]); 

                    outputText.Append(currChar);
                    bombPower += currBombPower;
                }
                else
                {
                    if (bombPower > 0)
                    {
                        bombPower --;
                    }
                    else
                    {
                        outputText.Append(currChar);
                    }
                }
            }

            Console.WriteLine(outputText.ToString());

        }

        static int GetIntValueOfCharacter(char ch)
        {
            return (int)ch - 48;
        }
    }
}
