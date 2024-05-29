namespace ValidationAttributes
{
    using Utilities;
    using Attributes;

    public class Person
    {
        private const int godiniMinimum = 12;
        private const int godiniMaximum = 90;

        [MyRequired]
        public string PulnoIme { get; set; }

        [MyRange(godiniMinimum, godiniMaximum)]
        public int Godini { get; set; }
        public Person(string pulnoime, int age)
        {
            this.PulnoIme = pulnoime;
            this.Godini = age;
        }
    }
}

