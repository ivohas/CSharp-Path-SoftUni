using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] teamArgs = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creatorName = teamArgs[0];
                string teamName = teamArgs[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team newTeam = new Team(teamName, creatorName);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArgs = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string memberName = joinArgs[0];
                string teamName = joinArgs[1];

                Team searchedTeam = teams
                    .FirstOrDefault(t => t.Name == teamName);

                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsAlreadyMemberOfTeam(teams, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(t => t.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                searchedTeam.AddMember(memberName);
            }

            List<Team> teamsWithMembers = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();
            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            PrintValidTeams(teamsWithMembers);
            PrintInvalidTeams(teamsToDisband);
        }

        static bool IsAlreadyMemberOfTeam(List<Team> teams, string memberName)
        {
            foreach (Team team in teams)
            {
                if (team.Members.Contains(memberName))
                {
                    return true;
                }
            }

            return false;
        }

        static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.Name}");
                Console.WriteLine($"- {validTeam.Creator}");

                foreach (string currMember in validTeam.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {currMember}");
                }
            }

        }

        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");
            foreach (Team invalidTeam in invalidTeams)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }

    }

    class Team
    {
        public Team(string teamName, string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;

            this.Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            this.Members.Add(member);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name}");
            sb.AppendLine($"- {this.Creator}");

            foreach (string currMember in this.Members.OrderBy(m => m))
            {
                sb.AppendLine($"-- {currMember}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}