namespace Wild
{

    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string param3, string param4 = null)
        {
            Animal anim;
            if (type == "Owl")
            {
                anim = new Owl(name, weight, double.Parse(param3));
            }
            else if (type == "Mouse")
            {
                anim = new Mouse(name, weight, param3);
            }
            else if (type == "Hen")
            {
                anim = new Hen(name, weight, double.Parse(param3));
            }
            else if (type == "Cat")
            {
                anim = new Cat(name, weight, param3, param4);
            }
            else if (type == "Dog")
            {
                anim = new Dog(name, weight, param3);
            }
            else if (type == "Tiger")
            {
                anim = new Tiger(name, weight, param3, param4);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return anim;
        }
    }
}