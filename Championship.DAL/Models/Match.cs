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
        public DateTime Date { get; set; }

        public override string ToString()
        {
            string players = "";
            foreach (var player in PlayersWhoScored)
                players += PlayersWhoScored.ToString() + '\n';

            return
                $"Team1:\n{Team1}\n" +
                $"Team2:\n{Team2}\n" +
                $"Team1 goals scored: {Team1GoalsScored}\n" +
                $"Team2 goals scored: {Team2GoalsScored}\n" +
                $"Players: {players}\n" +
                $"Date: {Date.ToShortDateString()}";
        }
    }
}
