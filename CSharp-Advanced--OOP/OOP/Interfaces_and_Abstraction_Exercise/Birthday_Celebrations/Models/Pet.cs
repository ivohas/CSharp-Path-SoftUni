using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations.Models
{
    using Models.Interfaces;
    public class Pet : IPet
    {
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
