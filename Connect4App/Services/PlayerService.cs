namespace Connect4App.Services;

using Connect4App.Data;
using Connect4App.Models;
using Microsoft.EntityFrameworkCore;


public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Player> LoginAsync(LoginRequest request)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Username == request.Username && p.Password == request.Password);
        if (player == null) throw new Exception("Invalid credentials");

        return player;
    }

    Task<Player> IPlayerService.LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}