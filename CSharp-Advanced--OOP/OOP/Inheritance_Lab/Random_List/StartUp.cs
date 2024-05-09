using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rl = new RandomList();

            rl.Add("kote");
            rl.Add("kuche");

            Console.WriteLine(rl.RandomString());
        }
    }
}
