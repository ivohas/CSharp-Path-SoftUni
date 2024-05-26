namespace Wild
{
    public abstract class Food
    {
        protected Food(int q)
        {
            this.Q = q;
        }

        public int Q { get; }
    }
}