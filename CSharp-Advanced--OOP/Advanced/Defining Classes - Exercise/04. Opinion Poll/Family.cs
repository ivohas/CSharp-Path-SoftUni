using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> familyMembers { get; set; }
        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.familyMembers.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = this.familyMembers.Max(member => member.Age);
            return this.familyMembers.First(member => member.Age == maxAge);
        }
    }
}