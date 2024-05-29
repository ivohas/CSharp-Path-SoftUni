using System;
using System.Collections.Generic;
using System.Text;

namespace Validation_Attributes.Utilities
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string value)
            {
                return !String.IsNullOrEmpty(value);
            }
            return obj != null;
        }
    }
}
