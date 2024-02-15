using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Championship.DAL;
using Championship.DAL.Models;
using System.Linq;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Відобразити інформацію про команди з бази даних");
                Console.WriteLine("2. Пошук інформації про команду за назвою");
                Console.WriteLine("3. Пошук команд за назвою міста");
                Console.WriteLine("4. Пошук інформації за назвою команди і міста");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PrintTeams(GetTeamsFromDb());
                        break;

                    case "2":
                        Console.WriteLine("Введіть ім\'я: ");
                        string name = Console.ReadLine();


                        break;

                    case "3":
                        Console.WriteLine("Введіть назву міста: ");
                        string town = Console.ReadLine();

                        break;

                    case "4":
                        Console.WriteLine("Введіть ім\'я: ");
                        string name2 = Console.ReadLine();
                        Console.WriteLine("Введіть назву міста: ");
                        string town2 = Console.ReadLine();

                        break;
                }
            }
            //FillTeams();
            //PrintTeamsFromDb();
            Console.ReadKey();
        }

        private static List<Team> FindTeamsByTown(in List<Team> teams, string town)
        {
            return (from team in teams
                    where team.Town == town
                    select team).ToList();
        }

        private static List<Team> FindTeamsByName(in List<Team> teams, string name)
        {
            return (from team in teams
                    where team.Name == name
                    select team).ToList();
        }


        static void FillTeams() 
        {
            Team team1 = new Team()
            {
                Name = "Name 1",
                Town = "Town 1",
                Wins = 5,
                Loses = 5,
                Draws = 4
            };

            Team team2 = new Team()
            {
                Name = "Name 2",
                Town = "Town 2",
                Wins = 5,
                Loses = 5,
                Draws = 4
            };

            using (var context = new ChampionshipContext())
            {
                if (context.Teams.Count() == 0)
                {
                    context.Teams.AddRange(team1, team2);
                    context.SaveChanges();
                }
            }
        }

        static List<Team> GetTeamsFromDb() 
        {
            using (var context = new ChampionshipContext())
            {
                return context.Teams.ToList();
            }
        }

        static void PrintTeams(in List<Team> teams) 
        {
            foreach (var team in teams) 
            {
                Console.WriteLine(
                  $"Name: {team.Name}\n" +
                  $"Town: {team.Town}\n" +
                  $"Wins: {team.Wins}\n" +
                  $"Loses: {team.Loses}\n" +
                  $"Draws: {team.Draws}\n" +
                  $"Goals conceded: {team.GoalsConceded}\n" +
                  $"Goals scored: {team.GoalsScored}\n");
            }
        }


    }
}