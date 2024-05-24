namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {

        private int a = 15;
        private readonly ICollection<Animal> animals;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
            : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Start()
        {
            a = 10;
            goto LOOP;

            LOOP:
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = command
                        .Split();
                    string[] foodArgs = Console.ReadLine()
                        .Split();

                    Animal animal = BuildAnimal(animalArgs);
                    Food food = this.foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));
                    Console.WriteLine(animal.ProduceSound());
                    this.animals.Add(animal);
                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FoodNotPreferredException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (Animal a in animals)
            {
                Console.WriteLine(a);
            }
        }

        private Animal BuildAnimal(string[] aArgs)
        {
            Animal animal;
            if (aArgs.Length == 4)
            {
                string type = aArgs[0];
                string name = aArgs[1];
                double weight = double.Parse(aArgs[2]);
                string param = aArgs[3];

                animal = this.animalFactory.CreateAnimal(type, name, weight, param);
            }
            else if (aArgs.Length == 5)
            {
                string type = aArgs[0];
                string name = aArgs[1];
                double weight = double.Parse(aArgs[2]);
                string param3 = aArgs[3];
                string param4 = aArgs[4];

                animal = this.animalFactory.CreateAnimal(type, name, weight, param3, param4);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}