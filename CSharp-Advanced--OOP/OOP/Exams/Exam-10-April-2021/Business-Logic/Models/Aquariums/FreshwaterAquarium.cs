namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int CAPACITY = 50;
        public FreshwaterAquarium(string name)
            : base(name, CAPACITY)
        {
        }
    }
}
