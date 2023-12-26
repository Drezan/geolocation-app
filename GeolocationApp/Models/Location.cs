using System.ComponentModel.DataAnnotations;

namespace GeolocationApp.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
