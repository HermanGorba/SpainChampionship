using Service = Championship.DAL.Service;
namespace App
{
    internal class Program
    {
        static void Main()
        {
            var service = new Service();
            
            while (true)
            {
                Utilities.PrintMenu();

                string choice = Console.ReadLine();

                Utilities.PrintTeams(Utilities.ExecuteRequest(service, choice));

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}