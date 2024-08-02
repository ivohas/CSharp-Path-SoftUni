using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public class MyRequiredAttribute : MyValidationAtribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                return !string.IsNullOrEmpty(str);
            }

            return obj != null;
        }
    }
}

