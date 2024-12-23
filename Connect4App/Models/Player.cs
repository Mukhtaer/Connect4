namespace Connect4App.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<Game>? HostedGames { get; set; }
        public List<Game>? GuestGames { get; set; }
    }
}