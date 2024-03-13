using Rent_A_Tesla.Data;
using Rent_A_Tesla.Models;

namespace Rent_A_Tesla.Seeders
{
    public class LocationSeeder
    {
        private readonly ApplicationDbContext _context;
        public LocationSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.Location.Any())
                {

                    var locations = new[]
                    {
                        new Location
                        {
                            Name = "Rent A Tesla Palma Airport",
                            Street = "Carrer de Can Calafat 81",
                            City = "Palma",
                            PostalCode = "07199",
                            Country = "Spain",
                            LocImage = "/images/locations/RentTesla_PalmaAirport.jpg"
                        },
                        new Location
                        {
                            Name = "Rent A Tesla Palma City Center",
                            Street = "Carrer de I`Uruguai",
                            City = "Palma",
                            PostalCode = "07010",
                            Country = "Spain",
                            LocImage = "/images/locations/RentTesla_PalmaCityCenter.jpg"
                        },
                        new Location
                        {
                            Name = "Rent A Tesla Alcudia",
                            Street = "Via de Corneli Atic",
                            City = "Alcudia",
                            PostalCode = "07400",
                            Country = "Spain",
                            LocImage = "/images/locations/RentTesla_Alcudia.jpg"
                        },
                        new Location
                        {
                            Name = "Rent A Tesla Manacor",
                            Street = "Via Palma 89",
                            City = "Manacor",
                            PostalCode = "07500",
                            Country = "Spain",
                            LocImage = "/images/locations/RentTesla_Manacor.jpg"
                        },
                    };

                    _context.Location.AddRange(locations);
                    await _context.SaveChangesAsync();

                }
            }
        }
    }
}
