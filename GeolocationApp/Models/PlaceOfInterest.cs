using System.ComponentModel.DataAnnotations;

namespace GeolocationApp.Models
{
    public class PlaceOfInterest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string BusinessType { get; set; } = null!;
    }
}
