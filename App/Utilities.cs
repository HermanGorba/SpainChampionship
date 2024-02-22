using Championship.DAL;
using Championship.DAL.Models;

namespace App
{
    public class Utilities
    {
        public static void PrintMenu()
        {
            Console.WriteLine("1. Відобразити інформацію про команди з бази даних");
            Console.WriteLine("2. Пошук інформації про команду за назвою");
            Console.WriteLine("3. Пошук команд за назвою міста");
            Console.WriteLine("4. Пошук інформації за назвою команди і міста");
            Console.WriteLine("5. Відображення команди з найбільшою кількістю перемог");
            Console.WriteLine("6. Відображення команди з найбільшою кількістю поразок");
            Console.WriteLine("7. Відображення команди з найбільшою кількістю ігор у нічию");
            Console.WriteLine("8. Відображення команди з найбільшою кількістю забитих голів");
            Console.WriteLine("9. Відображення команди з найбільшою кількістю пропущених голів");
            Console.WriteLine("10. Додати нову команду");
            Console.WriteLine("11. Зміна даних існуючої команди");
            Console.WriteLine("12. Видалити команду");
            Console.WriteLine("13. Відобразити різницю забитих та пропущених голів для кожної команди");
            Console.WriteLine("-14. Відобразити повну інформацію про матч");
            Console.WriteLine("-15. Покажіть інформацію про матчі у конкретну дату");
            Console.WriteLine("-16. Покажіть усі матчі конкретної команди");
            Console.WriteLine("-17. Покажіть усіх гравців, які забили голи у конкретну дату");
            Console.WriteLine("-18. Додати новий матч");
            Console.WriteLine("-19. Зміна даних існуючого матчу");
            Console.WriteLine("-20. Видалити матч");

            Console.WriteLine("0. Вихід");
        }
        public static List<Team> ExecuteRequest(in Service service, in string? choice)
        {
            switch (choice)
            {
                case "1":
                    return service.GetTeams();

                case "2":
                    Console.WriteLine("Введіть назву команди: ");
                    var name = Console.ReadLine();
                    return new List<Team>() { service.FindTeamByName(name) };


                case "3":
                    Console.WriteLine("Введіть назву міста: ");
                    var town = Console.ReadLine();
                    return service.FindTeamsByTown(town);


                case "4":
                    Console.WriteLine("Введіть назву команди: ");
                    var name2 = Console.ReadLine();
                    Console.WriteLine("Введіть назву міста: ");
                    var town2 = Console.ReadLine();

                    return new List<Team>() { service.FindTeamByNameAndTown(name2, town2) };


                case "5":
                    return new List<Team>() { service.TeamWithTheMostWins };

                case "6":
                    return new List<Team>() { service.TeamWithTheMostLoses };

                case "7":
                    return new List<Team>() { service.TeamWithTheMostDraws };

                case "8":
                    return new List<Team>() { service.TeamWithTheMostGoalsScored };

                case "9":
                    return new List<Team>() { service.TeamWithTheMostGoalsConceded };

                case "10":
                    if (service.AddTeam(ReadTeam()))
                        Console.WriteLine("Команда додана успішно");
                    else
                        Console.WriteLine("Команда не додана");
                    break;

                case "11":
                    Console.WriteLine("Введіть назву команди: ");
                    var name3 = Console.ReadLine();
                    Console.WriteLine("Введіть назву міста: ");
                    var town3 = Console.ReadLine();

                    Console.WriteLine("Введіть нову інформацію про команду:");

                    if (service.EditTeam(name3, town3, ReadTeam()))
                        Console.WriteLine("Команда відредаговвна успішно");
                    else
                        Console.WriteLine("Команда не відредагована");
                    break;

                case "12":
                    Console.WriteLine("Введіть назву команди: ");
                    var name4 = Console.ReadLine();
                    Console.WriteLine("Введіть назву міста: ");
                    var town4 = Console.ReadLine();
                    Console.WriteLine("Дійсно хочете видалити команду? +/-");
                    if (Console.ReadKey().KeyChar == '+')
                    {
                        if (service.RemoveTeam(name4, town4))
                            Console.WriteLine("Команда видалена успішно");
                        else
                            Console.WriteLine("Команда не видалена");
                    }
                    else
                        Console.WriteLine("Видалення успішно відмінено");
                    break;

                case "13":
                    foreach (var pair in service.GetGoalDifferenceByTeam())
                        Console.WriteLine($"{pair.Key.Name} {pair.Value}");

                    break;
            }

            return new List<Team>();
        }
        public static void PrintTeams(in List<Team> teams)
        {
            foreach (var team in teams)
                PrintTeam(team);

        }
        private static void PrintTeam(in Team? team)
        {
            if (team != null)
            {
                Console.WriteLine(team.ToString());
            }
        }
        private static Team? ReadTeam()
        {
            try
            {
                Console.WriteLine("Введіть назву команди: ");
                string teamName = Console.ReadLine();
                Console.WriteLine("Введіть назву міста: ");
                string teamTown = Console.ReadLine();
                Console.WriteLine("Введіть кількість перемог");
                int wins = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть кількість нічиїх: ");
                int draws = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть кількість поразок: ");
                int loses = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть кількість пропущених голів: ");
                int goalsConceded = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть кількість забитих голів");
                int goalsScored = int.Parse(Console.ReadLine());

                return new Team()
                {
                    Name = teamName,
                    Town = teamTown,
                    Draws = draws,
                    Wins = wins,
                    Loses = loses,
                    GoalsConceded = goalsConceded,
                    GoalsScored = goalsScored
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
