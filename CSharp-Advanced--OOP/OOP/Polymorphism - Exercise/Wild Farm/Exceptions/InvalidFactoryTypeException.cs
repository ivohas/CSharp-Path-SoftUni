namespace Wild
{
    using System;

    public class InvalidFactoryTypeException : Exception
    {
        private const string msg = "Invalid type!";

        public InvalidFactoryTypeException()
            : base(msg)
        {

        }

        public InvalidFactoryTypeException(string msg)
            : base(msg)
        {

        }
    }
}