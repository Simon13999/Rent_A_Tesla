using System.ComponentModel.DataAnnotations;

namespace Rent_A_Tesla.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        public string? PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        public string? LocImage { get; set; }
        public virtual ICollection<OurCars> Car { get; set; } // Auta dostępne w danej lokalizacji

        public Location()
        {
            Car = new HashSet<OurCars>();
        }
    }
}
