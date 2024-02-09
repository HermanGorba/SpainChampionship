namespace Championship.DAL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Draws { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalsScored { get; set; }
    }
}
