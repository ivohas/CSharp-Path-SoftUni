using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    };

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries);

                Song song = new Song()
                {
                    TypeList = cmdArgs[0],
                    Name = cmdArgs[1],
                    Time = cmdArgs[2]
                 };


                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

        }
    }
}
