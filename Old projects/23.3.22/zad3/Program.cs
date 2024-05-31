using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Song
    {
        public string Type { get; set; }
        public string name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> listOfSong = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {


                List<string> list = Console.ReadLine().Split('_').ToList();
                string type = list[0];
                string name = list[1];
                string time = list[2];
                Song newSong = new Song()
                {
                    Type = type,
                    name = name,
                    Time = time

                };
                listOfSong.Add(newSong);
            }
            string command = Console.ReadLine();
            if (command == "all")
            {
                foreach (Song song in listOfSong)
                {
                    Console.WriteLine(song.name);

                }

            }
            else
            {
                List<Song> filter = listOfSong.FindAll(song => song.Type == command);
                Console.WriteLine(filter);
            }
        }
    }
}
