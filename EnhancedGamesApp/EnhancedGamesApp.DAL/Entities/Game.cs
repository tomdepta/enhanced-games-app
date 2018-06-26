namespace EnhancedGamesApp.DAL.Entities
{
    public class Game
    {
        public string Key { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public bool FourKConfirmed { get; set; }

        public bool HdrRenderingAvailable { get; set; }

        public AvailabilityStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Game game &&
                   Key == game.Key;
        }

        protected bool Equals(Game other)
        {
            return string.Equals(Key, other.Key);
        }

        public override int GetHashCode()
        {
            return Key != null ? Key.GetHashCode() : 0;
        }
    }
}
