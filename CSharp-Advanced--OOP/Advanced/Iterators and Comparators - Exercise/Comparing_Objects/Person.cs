using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ListyIterator
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public string Name => name;
        public int Age => age;
        public string Town => town;
        
        public int CompareTo([AllowNull] Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
