﻿using System.Collections.Generic;
using EnhancedGamesApp.DAL.Entities;

namespace EnhancedGamesApp.DAL.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetGames();

        void AddGames(IEnumerable<Game> gamesToAdd);

        void UpdateGames(IEnumerable<Game> gamesToUpdate);
    }
}
