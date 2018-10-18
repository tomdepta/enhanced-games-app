using EnhancedGamesApp.DAL.Entities;
using EnhancedGamesApp.DAL.Repositories;
using EnhancedGamesApp.Shared.Services.Providers;
using FluentScheduler;
using System.Linq;

namespace EnhancedGamesApp.Console.Shared.Jobs
{
    public class UpdateGamesListJob : IJob
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGamesListProvider _listProvider;

        public UpdateGamesListJob(IGameRepository gameRepository, IGamesListProvider listProvider)
        {
            _gameRepository = gameRepository;
            _listProvider = listProvider;
        }

        public async void Execute()
        {
            var gamesFromProvider = _listProvider.GetGamesList().ToList();
            var cachedGames = await _gameRepository.GetGamesAsync();

            var newGames = gamesFromProvider.Where(x => cachedGames.All(y => !y.Equals(x))).ToList();
            if (newGames.Any())
            {
                await _gameRepository.AddGamesAsync(newGames);
            }

            var gamesToUpdate = cachedGames
                .Where(x => x.RequiresUpdate(gamesFromProvider.FirstOrDefault(y => y.Equals(x)))).ToList();

            if (gamesToUpdate.Any())
            {
                gamesToUpdate.ForEach(game =>
                {
                    var newVersion = gamesFromProvider.First(g => g.Equals(game));
                    game.FourKConfirmed = newVersion.FourKConfirmed;
                    game.HdrRenderingAvailable = newVersion.HdrRenderingAvailable;
                    game.Status = newVersion.Status;
                });

                await _gameRepository.UpdateGamesAsync(gamesToUpdate);
            }
        }
    }
}