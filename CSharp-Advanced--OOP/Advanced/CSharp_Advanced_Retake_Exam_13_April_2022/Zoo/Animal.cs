namespace Zoo
{
    public class Animal
    {
        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }

        public Animal(string species, string diet, double wieght, double length)
        {
            this.Species = species;
            this.Diet = diet;
            this.Weight = wieght;
            this.Length = length;
        }

        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }
    }
}
