using System;
using System.Collections.Generic;
using System.Linq;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    ProcessInfo(teams, cmdArgs);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        static void ProcessInfo(List<Team> teams, string[] cmdArgs)
        {
            string cmdType = cmdArgs[0];
            string teamName = cmdArgs[1];

            if (cmdType == "Team")
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            else
            {
                
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new InvalidOperationException(
                            String.Format(ErrorMessages.TeamNotExisting, teamName));
                }
                if (cmdType == "Add")
                {
                    string playerName = cmdArgs[2];

                    Stats playerStats = GeneratePlayerStats(cmdArgs.Skip(3).ToArray());
                    Player player = new Player(playerName, playerStats);
                    team.AddPlayer(player);
                }
                else if (cmdType == "Remove")
                {
                    string playerName = cmdArgs[2];
                    team.RemovePlayer(playerName);
                }
                else if (cmdType == "Rating")
                {
                    Console.WriteLine(team);
                }
            }
            
        }

        static Stats GeneratePlayerStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats generatedStats = new Stats(endurance, sprint, dribble, passing, shooting);

            return generatedStats;
        }
    }
}
