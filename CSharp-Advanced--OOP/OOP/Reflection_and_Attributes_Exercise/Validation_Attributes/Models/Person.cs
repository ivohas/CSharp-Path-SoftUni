using Validation_Attributes.Utilities;

namespace Validation_Attributes.Models
{
    public class Person
    {
        private const int mingodini = 12;
        private const int maxgodini = 90;

        [MyRange(mingodini, maxgodini)]
        public int Godini { get; set; }

        [MyRequired]
        public string PulnoIme { get; set; }

        public Person(string pulnoIme, int godini)
        {
            this.PulnoIme = pulnoIme;
            this.Godini = godini;
        }
    }
}
