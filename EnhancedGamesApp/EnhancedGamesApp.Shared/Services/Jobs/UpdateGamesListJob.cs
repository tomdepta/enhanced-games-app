using EnhancedGamesApp.DAL.Entities;
using EnhancedGamesApp.DAL.Repositories;
using EnhancedGamesApp.Shared.Services.Providers;
using FluentScheduler;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EnhancedGamesApp.Console.Shared.Jobs
{
    public class UpdateGamesListJob : IJob
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGamesListProvider _listProvider;
        private readonly ILogger _logger;

        public UpdateGamesListJob(IGameRepository gameRepository, IGamesListProvider listProvider, ILogger logger)
        {
            _gameRepository = gameRepository;
            _listProvider = listProvider;
            _logger = logger;
        }

        public async void Execute()
        {
            try
            {
                var gamesFromProvider = _listProvider.GetGamesList().ToList();
                var cachedGames = await _gameRepository.GetGamesAsync();

                var newGames = gamesFromProvider.Where(x => cachedGames.All(y => !y.Equals(x))).ToList();
                if (newGames.Any())
                {
                    await _gameRepository.AddGamesAsync(newGames);
                }
                _logger.LogInformation($"{newGames.Count} games added to the list.");

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
                _logger.LogInformation($"{gamesToUpdate.Count} games have been updated.");
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occured during update list job: {e.Message}");
            }
        }
    }
}