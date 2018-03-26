﻿using System.Linq;
using EnhancedGamesApp.DAL.Repositories;
using FluentScheduler;

namespace EnhancedGamesApp.Console.Services.Schedule
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

        public void Execute()
        {
            var gamesFromProvider = _listProvider.GetGamesList();
            var cachedGames = _gameRepository.GetGames();

            var newGames = gamesFromProvider.Where(x => cachedGames.All(y => !y.Equals(x))).ToList();
            _gameRepository.AddGames(newGames);
        }
    }
}