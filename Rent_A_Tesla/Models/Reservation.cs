using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Rent_A_Tesla.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [DisplayName("Date of reservation")]
        public DateTime Date { get; set; } = DateTime.UtcNow; // Kiedy była wykonana rezerwacja
        [DisplayName("Pickup location")]
        public int PickupLocationId { get; set; }
        [DisplayName("Pickup location")]
        public virtual Location? PickupLocation { get; set; } // Lokalizacja wypożyczenia
        [DisplayName("Return location")]
        public int ReturnLocationId { get; set; }
        [DisplayName("Car model")]
        public int CarId { get; set; }
        public virtual OurCars? Car { get; set; } // jakie auto
        [DisplayName("Return location")]
        public virtual Location? ReturnLocation { get; set; } // Lokalizacja zwrotu
        [DisplayName("Reservation start")]
        public DateTime StartRes { get; set; }
        [DisplayName("Reservation end")]
        public DateTime EndRes { get; set; }
        [DisplayName("Total cost")]
        public decimal Amount { get; set; }
        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}
