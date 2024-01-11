using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person person = new Person();
            Person person2 = new Person("Gosho", 20);
            Person person3 = new Person("IlchoKukata", 69);

            Console.WriteLine($"{person.Name} is {person.Age} years old");
        }
    }
}
