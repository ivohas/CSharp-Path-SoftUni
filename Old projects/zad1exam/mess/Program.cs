using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> usernamesAndRec = new Dictionary<string, int>();
            int capacity = int.Parse(Console.ReadLine());

            string cmds = Console.ReadLine();
            int records = 0;
            while (cmds != "Statistics")
            {
                string[] cmdArgs = cmds
                    .Split('=')
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    string username = cmdArgs[1];
                    int sent = int.Parse(cmdArgs[2]);
                    int received = int.Parse(cmdArgs[3]);

                    records = sent + received;
                    if (usernamesAndRec.ContainsKey(username))
                    {
                        return;
                    }
                    usernamesAndRec.Add(username, records);

                }
                else if (cmdType == "Message")
                {
                    string sender = cmdArgs[1];
                    string receiver = cmdArgs[2];

                    if (usernamesAndRec.ContainsKey(sender) && usernamesAndRec.ContainsKey(receiver))
                    {
                        usernamesAndRec[sender] += 1;
                        usernamesAndRec[receiver] += 1;

                    }

                    foreach (var item in usernamesAndRec.Values)
                    {
                        if (item >= capacity)
                        {
                            var myKey = usernamesAndRec.FirstOrDefault(x => x.Value == item).Key;
                            Console.WriteLine($"{myKey} reached the capacity!");
                            usernamesAndRec.Remove(myKey);
                        }
                    }

                }
                else if (cmdType == "Empty")
                {
                    string username = cmdArgs[1];
                    if (usernamesAndRec.ContainsKey(username))
                    {
                        usernamesAndRec.Remove(username);
                    }
                    if (username == "All")
                    {
                        usernamesAndRec.Clear();
                    }
                }

                cmds = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {usernamesAndRec.Count}");
            foreach (KeyValuePair<string, int> kvp in usernamesAndRec)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
