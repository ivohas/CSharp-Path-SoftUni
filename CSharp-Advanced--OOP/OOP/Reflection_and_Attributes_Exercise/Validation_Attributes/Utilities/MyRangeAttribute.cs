using System;
namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAtribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int value)
            {
                return value >= minValue && value <= maxValue;
            }

            return false;
        }
    }
}

