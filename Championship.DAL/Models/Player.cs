namespace Championship.DAL.Models
{
    public class Player
    {
        public int Id { get; set; }
        public Team team { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
        public string Position { get; set; }
    }
}
