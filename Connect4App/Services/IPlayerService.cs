
using Connect4App.Models;

namespace Connect4App.Services;
public interface IPlayerService
{
    Task<Player> LoginAsync(LoginRequest request);
}