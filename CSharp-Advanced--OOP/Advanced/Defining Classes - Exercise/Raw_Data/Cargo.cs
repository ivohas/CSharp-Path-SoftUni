using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo()
        {

        }
        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }
        public int Weight { get { return weight; } set { weight = value; } }
        public string Type { get { return type; } set { type = value; } }
    }
}
