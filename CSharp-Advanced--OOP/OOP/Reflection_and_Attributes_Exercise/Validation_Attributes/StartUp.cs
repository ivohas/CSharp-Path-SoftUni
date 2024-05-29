using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main()
        {
            var person = new Person
            (
                "Gosho",
                18
            );
            goto LOOP;
            LOOP:
            bool isValid = Validator.IsValid(person);

            Console.WriteLine(isValid);
        }
    }
}
