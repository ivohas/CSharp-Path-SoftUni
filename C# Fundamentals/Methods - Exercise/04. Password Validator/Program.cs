using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int passwordMinLenght = 6;
            const int passwordMaxLenght = 10;
            const int passwordDigitsMinCount = 2;

            string password = Console.ReadLine();

            bool isPasswordValid = ValidatePassword(password, passwordMinLenght, passwordMaxLenght, passwordDigitsMinCount);

            if (isPasswordValid) Console.WriteLine("Password is valid");
        }

        static bool ValidatePassword(string password, int passwordMinLenght, int passwordMaxLenght, int passwordDigitsMinCount)
        {

            bool isPasswordValid = true;
            if (!ValidatePasswordLength(password, passwordMinLenght, passwordMaxLenght))
            {
                Console.WriteLine($"Password must be between {passwordMinLenght} and {passwordMaxLenght} characters");
                isPasswordValid = false;
            }
            if (!ValidatePasswordIsLetterOrDigit(password))
            {
                Console.WriteLine($"Password must consist only of letters and digits");
                isPasswordValid = false;
            }
            if (!ValidatePasswordDigitsMinCount(password, passwordDigitsMinCount))
            {
                Console.WriteLine($"Password must have at least 2 digits");
                isPasswordValid = false;
            }

            return isPasswordValid;
        }

        static bool ValidatePasswordLength(string password, int minLength, int maxLength)
        {
            if (password.Length >= minLength && password.Length <= maxLength)
            {
                return true;
            }

            return false;
        }

        static bool ValidatePasswordIsLetterOrDigit(string passowrd)
        {
            foreach (char ch in passowrd)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
                return true;
        }

        static bool ValidatePasswordDigitsMinCount(string password, int minDigitCount)
        {
            int digitsCount = 0;
            foreach (char ch in password)
            {
                if (Char.IsDigit(ch))
                {
                    digitsCount++;
                }
            }

            return digitsCount >= minDigitCount;
        }
    }
}
