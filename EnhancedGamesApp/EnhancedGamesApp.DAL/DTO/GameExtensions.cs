namespace EnhancedGamesApp.DAL.DTO
{
    public static class GameExtensions
    {
        public static bool RequiresUpdate(this Game game, Game previousVersion)
        {
            if (game == null || previousVersion == null)
            {
                return false;
            }

            return game.FourKConfirmed != previousVersion.FourKConfirmed ||
                   game.HdrRenderingAvailable != previousVersion.HdrRenderingAvailable ||
                   game.Status != previousVersion.Status;
        }
    }
}
