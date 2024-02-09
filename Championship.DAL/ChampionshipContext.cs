using Microsoft.EntityFrameworkCore;

namespace Championship.DAL
{
    public class ChampionshipContext : DbContext
    {
        public DbSet<Models.Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Championship;Integrated Security=True;Connect Timeout=30;");
        }
    }
}