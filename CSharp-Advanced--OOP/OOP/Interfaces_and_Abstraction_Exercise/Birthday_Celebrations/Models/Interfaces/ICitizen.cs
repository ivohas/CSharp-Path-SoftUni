using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control.Models.Interfaces
{
    public interface ICitizen
    {
        public string Name { get; }
        public int Age { get; }
        public string ID { get; }
        public string Birthdate { get; }
    }
}
