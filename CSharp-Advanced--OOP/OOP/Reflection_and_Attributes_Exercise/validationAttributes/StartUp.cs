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
                17
            );

            goto LOOP;
            LOOP:

            Console.WriteLine(Validator.IsValid(person));
        }
    }
}
