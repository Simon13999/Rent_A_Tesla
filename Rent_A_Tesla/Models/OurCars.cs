using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rent_A_Tesla.Models
{
    public class OurCars // Przedstawia jakie posiadamy auta
    {
        public int Id { get; set; }
        [DisplayName("Model")]
        public int CarId { get; set; } // Model z CarModel
        public virtual CarModel? Car { get; set; }
        public string MaxSpeed { get; set; }
        public string Range { get; set; }
        public int Seats { get; set; }
        [Required]
        [DisplayName("Price per day")]
        public decimal PricePerDay { get; set; }
        [Required]
        [DisplayName("Available")]
        public bool IsAvailable { get; set; }
        [DisplayName("Location")]
        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }
        [DisplayName("Image")]
        public string? OurCarImage { get; set; }
        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}
