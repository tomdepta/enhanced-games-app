using System.ComponentModel.DataAnnotations;

namespace EnhancedGamesApp.DAL.Entities
{
    public class Game
    {
        [Key]
        [Required]
        public string Key { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
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
