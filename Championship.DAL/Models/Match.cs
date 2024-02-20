namespace Championship.DAL.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1GoalsScored { get; set; }
        public int Team2GoalsScored { get; set; }
        public List<Player> PlayersWhoScored { get; set; }
        public DateOnly Date { get; set; }
    }
}
