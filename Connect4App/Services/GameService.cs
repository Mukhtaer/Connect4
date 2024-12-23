

using Connect4App.Data;
using Connect4App.Models;
using Microsoft.EntityFrameworkCore;

namespace Connect4App.Services;
public class GameService : IGameService
{
    private readonly AppDbContext _context;

    public GameService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Game> CreateGameAsync(CreateGameRequest request)
    {
        var host = await _context.Players.FirstOrDefaultAsync(p => p.Username == request.HostUsername);
        if (host == null) throw new Exception("Host not found");

        var game = new Game
        {
            Host = host,
            Grid = new Grid { State = string.Empty },
            Status = "Awaiting Guest"
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return game;
    }
    public async Task<Game> JoinGameAsync(JoinGameRequest request)
    {
        var game = await _context.Games.Include(g => g.Host).FirstOrDefaultAsync(g => g.Id == request.GameId);
        if (game == null) throw new Exception("Game not found");

        var guest = await _context.Players.FirstOrDefaultAsync(p => p.Username == request.GuestUsername);
        if (guest == null) throw new Exception("Guest not found");

        game.Guest = guest;
        game.Status = "In Progress";

        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<Game> MakeMoveAsync(MakeMoveRequest request)
    {
        var game = await _context.Games.Include(g => g.Grid).FirstOrDefaultAsync(g => g.Id == request.GameId);
        if (game == null) throw new Exception("Game not found");

        // Implement move logic here

        await _context.SaveChangesAsync();

        return game;
    }
}