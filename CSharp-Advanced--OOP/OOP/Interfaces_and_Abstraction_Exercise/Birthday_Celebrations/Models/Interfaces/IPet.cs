using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations.Models.Interfaces
{
    public interface IPet
    {
        public string Name { get; }
        public string Birthdate { get; }
    }
}
