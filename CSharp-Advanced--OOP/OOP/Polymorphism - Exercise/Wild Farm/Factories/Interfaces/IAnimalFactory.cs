namespace Wild
{

    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string param3, string param4 = null);
    }
}