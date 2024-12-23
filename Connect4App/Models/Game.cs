namespace Connect4App.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int HostId { get; set; }
        public Player? Host { get; set; }
        public int? GuestId { get; set; }
        public Player? Guest { get; set; }
        public Grid? Grid { get; set; }
        public string? Status { get; set; }
    }
}