namespace Connect4App.Models{
public class MakeMoveRequest
{
    public int GameId { get; set; }
    public string? PlayerUsername { get; set; }
    public int Column { get; set; }
}
}