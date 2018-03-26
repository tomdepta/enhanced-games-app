namespace EnhancedGamesApp.DAL.DTO
{
    public class Game
    {
        public string Title { get; set; }

        public string Publisher { get; set; }

        public bool FourKConfirmed { get; set; }

        public bool HdrRenderingAvailable { get; set; }

        public AvailabilityStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Game)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Title != null ? Title.GetHashCode() : 0) * 397) ^ (Publisher != null ? Publisher.GetHashCode() : 0);
            }
        }

        private bool Equals(Game other)
        {
            return string.Equals(Title, other.Title) && string.Equals(Publisher, other.Publisher);
        }
    }
}
