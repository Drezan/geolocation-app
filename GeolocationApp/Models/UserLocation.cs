using System.ComponentModel.DataAnnotations.Schema;

namespace GeolocationApp.Models
{
    public class UserLocation
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public DateTime TimeStamp_Start { get; set; } = DateTime.Now;
        public DateTime TimeStamp_End { get; set; }
        public User User { get; set; } = null!;
        public Location Location { get; set; } = null!;
    }
}
