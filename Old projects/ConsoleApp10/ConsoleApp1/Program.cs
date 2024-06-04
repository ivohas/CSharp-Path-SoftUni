using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {     List<string> commands = new List<string>();
            string password = Console.ReadLine();
            string command=Console.ReadLine();
            string newPass = null;
            while (command!="Done")
            { commands = command.Split(' ').ToList();

                if (commands[0] == "TakeOdd")
                {
                    char[] chars = password.ToCharArray();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            
                            char odd = chars[i];
                            newPass += odd.ToString();
                            password = newPass;
                        }

                    }
                    Console.WriteLine(password);
                    break;
                } else if (commands[0]=="Cut") 
                {
                    newPass = null;
                    int index =int.Parse(commands[1]);
                    int lengh=int.Parse(commands[2]);
                   password = password.Substring(index, lengh);
                    password =newPass.Remove(0, 1);
                    Console.WriteLine(newPass);
                }else if (commands[0]== "Substitute")
                {
                    newPass= null;
                    string substring= commands[1];
                    string subsitute= commands[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, subsitute);
                        Console.WriteLine(password);
                    }
                    else 
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
