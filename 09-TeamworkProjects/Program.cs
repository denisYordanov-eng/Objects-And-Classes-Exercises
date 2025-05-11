using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_TeamworkProjects
{
    class Program
    {
        class Team 
        {
            public string Creator { get; set; }
            public string TeamName { get; set; }
            public List<string> Members { get; set; } = new List<string>();
        }


        static void Main(string[] args)
        {
            var teams = CreatingTeams();
            AddingMembers(teams);
            PrintTeams(teams);
        }

        private static void PrintTeams(List<Team> teams)
        {
            var filterdTeams = teams.Where(t => t.Members.Count > 0)
                 .OrderByDescending(t => t.Members.Count)
                 .ThenBy(n => n.TeamName);

            foreach (var team in filterdTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(a => a))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in teams.Where(a => a.Members.Count == 0)
                .OrderBy(a => a.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }

        private static void AddingMembers(List<Team> team)
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "end of assignment")
                {
                    break;
                }
                string[] input = inputLine.Split(new[] { "->" },StringSplitOptions.None);
                string member = input[0].Trim();
                string teamName = input[1].Trim();

                var teamMember = team.FirstOrDefault(a => a.TeamName == teamName);

                if (teamMember == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (team.Any(t => t.Creator == member || t.Members.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }
                teamMember.Members.Add(member);
            }
           
        }

         static List<Team> CreatingTeams()
        {
            List<Team> newTeams = new List<Team>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                String[] input = Console.ReadLine().Split('-');
                string creator = input[0];
                string teamName = input[1];

                if(newTeams.Any(t => t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if(newTeams.Any(c => c.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team newTeam = new Team();
                    newTeam.TeamName = teamName;
                    newTeam.Creator = creator;
                    newTeams.Add(newTeam);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
            return newTeams;
        }
    }
}
