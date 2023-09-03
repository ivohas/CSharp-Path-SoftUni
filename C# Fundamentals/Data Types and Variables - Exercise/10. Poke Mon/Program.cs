using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int targetsPoked = 0;

            double originalValue = pokemonPower * 0.50;

            while (pokemonPower >= distance)
            {
                if (pokemonPower == originalValue)
                {
                    if (exhaustionFactor > 0)
                    {
                        pokemonPower = pokemonPower / exhaustionFactor;

                        if (pokemonPower < distance)
                        {
                            break;
                        }
                    }

                }

                pokemonPower -= distance;
                targetsPoked++;
            }

            Console.WriteLine(pokemonPower);
            Console.WriteLine(targetsPoked);
        }
    }
}
