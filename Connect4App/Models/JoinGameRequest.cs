namespace Connect4App.Models
{
public class JoinGameRequest
{
    public int GameId { get; set; }
    public string? GuestUsername { get; set; }
}
}