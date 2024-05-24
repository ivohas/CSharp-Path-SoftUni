namespace Wild
{
    using System;

    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string msg)
            : base(msg)
        {

        }
    }
}