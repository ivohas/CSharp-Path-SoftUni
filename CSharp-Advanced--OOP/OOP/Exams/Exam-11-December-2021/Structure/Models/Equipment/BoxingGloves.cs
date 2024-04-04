using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double WEIGHT = 227;
        private const decimal PRICE = 120;
        public BoxingGloves()
            : base(WEIGHT, PRICE)
        {
        }
    }
}
