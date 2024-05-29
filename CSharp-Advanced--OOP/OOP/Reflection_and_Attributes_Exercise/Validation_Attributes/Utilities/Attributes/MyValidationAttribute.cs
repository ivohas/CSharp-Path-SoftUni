using System;

namespace Validation_Attributes.Utilities
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
