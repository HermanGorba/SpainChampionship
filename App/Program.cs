using Service = Championship.DAL.Service;
using Team = Championship.DAL.Models.Team;
using Match = Championship.DAL.Models.Match;
using Player = Championship.DAL.Models.Player;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Data.SqlClient;

namespace App
{
    internal class Program
    {
        static void Main()
        {
            var service = new Service();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Championship;Integrated Security=True;Connect Timeout=30;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Создание команд
                List<Team> teams = new List<Team>();
                for (int i = 1; i <= 10; i++)
                {
                    Team team = new Team { Name = $"Team {i}", Town = $"Town {i}" };
                    teams.Add(team);
                    SaveData(connection, team);
                }

                // Создание игроков
                List<Player> players = new List<Player>();
                int playerId = 1;
                foreach (var team in teams)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Player player = new Player { FullName = $"Player {playerId}", Country = $"Country {i}", Number = $"{i}", Position = $"Position {i}", team = team };
                        players.Add(player);
                        SaveData(connection, player);
                        playerId++;
                    }
                }

                // Создание матчей
                Random rnd = new Random();
                for (int i = 0; i < 20; i++)
                {
                    Match match = new Match
                    {
                        Team1 = teams[rnd.Next(teams.Count)],
                        Team2 = teams[rnd.Next(teams.Count)],
                        Team1GoalsScored = rnd.Next(5),
                        Team2GoalsScored = rnd.Next(5),
                        PlayersWhoScored = new List<Player> { players[rnd.Next(players.Count)] },
                        Date = DateTime.Now.AddDays(-rnd.Next(1, 30))
                    };
                    SaveData(connection, match);
                }
            }

            while (true)
            {
                Utilities.PrintMenu();

                string choice = Console.ReadLine();

                Utilities.PrintTeams(Utilities.ExecuteRequest(service, choice));

                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void SaveData(SqlConnection connection, object obj)
        {
            string tableName = obj.GetType().Name + "s";
            string sqlQuery = $"INSERT INTO {tableName} VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9)";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@value1", GetValue(obj, "Id"));
                command.Parameters.AddWithValue("@value2", GetValue(obj, "players"));
                command.Parameters.AddWithValue("@value3", GetValue(obj, "Name"));
                command.Parameters.AddWithValue("@value4", GetValue(obj, "Town"));
                command.Parameters.AddWithValue("@value5", GetValue(obj, "Wins"));
                command.Parameters.AddWithValue("@value6", GetValue(obj, "Loses"));
                command.Parameters.AddWithValue("@value7", GetValue(obj, "Draws"));
                command.Parameters.AddWithValue("@value8", GetValue(obj, "GoalsConceded"));
                command.Parameters.AddWithValue("@value9", GetValue(obj, "GoalsScored"));

                command.ExecuteNonQuery();
            }
        }

        public static object GetValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
    }
}