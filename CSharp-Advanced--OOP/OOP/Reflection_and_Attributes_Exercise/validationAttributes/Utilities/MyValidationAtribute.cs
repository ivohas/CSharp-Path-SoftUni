namespace ValidationAttributes.Attributes
{
    using System;

    public abstract class MyValidationAtribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}

