using Connect4App.Models;

namespace Connect4App.Services;
public interface IGameService
{
    Task<Game> CreateGameAsync(CreateGameRequest request);
    Task<Game> JoinGameAsync(JoinGameRequest request);
    Task<Game> MakeMoveAsync(MakeMoveRequest request);
}