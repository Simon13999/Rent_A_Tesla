using System.ComponentModel.DataAnnotations;

namespace Rent_A_Tesla.Models
{
    public class CarModel // Przedstawia jakie posiadamy modele aut, a nie jakie auta posiadamy
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Production { get; set; }
        public string BodyStyle { get; set; }
        [Required]
        public string Seats { get; set; }
        public string? CarImage { get; set; }
    }
}
