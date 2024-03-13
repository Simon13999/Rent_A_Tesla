using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rent_A_Tesla.Data;
using Rent_A_Tesla.Models;

namespace Rent_A_Tesla.Seeders
{/*
    public class OurCarSeeder
    {
        private readonly ApplicationDbContext _dbcontext;
        public OurCarSeeder(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Seed()
        {
            if (await _dbcontext.Database.CanConnectAsync())
            {
                var modelS = _dbcontext.CarModel.FirstOrDefault(c => c.Model == "Model S");
                var model3 = _dbcontext.CarModel.FirstOrDefault(c => c.Model == "Model 3");
                var modelX = _dbcontext.CarModel.FirstOrDefault(c => c.Model == "Model X");
                var modelY = _dbcontext.CarModel.FirstOrDefault(c => c.Model == "Model Y");
                var cybertruck = _dbcontext.CarModel.FirstOrDefault(c => c.Model == "Model Cybertruck");

                if (!_dbcontext.OurCars.Any())
                {
                    


                    var ourCars = new []
                    {
                        
                        new OurCars
                        {
                            Car = modelS,
                            MaxSpeed = "201",
                            Range = "483",
                            Seats = 5,
                            PricePerDay = 100,
                            IsAvailable = true,
                            LocationId = 1,
                            OurCarImage = "/images/model-S.jpg"
                        },
                        new OurCars
                        {
                            Car = modelS,
                            MaxSpeed = "201",
                            Range = "483",
                            Seats = 5,
                            PricePerDay = 100,
                            IsAvailable = true,
                            LocationId = 2,
                            OurCarImage = "/images/model-S.jpg"
                        },
                        new OurCars
                        {
                            Car = modelS,
                            MaxSpeed = "201",
                            Range = "483",
                            Seats = 5,
                            PricePerDay = 100,
                            IsAvailable = true,
                            LocationId = 3,
                            OurCarImage = "/images/model-S.jpg"
                        },
                        new OurCars
                        {
                            Car = modelS,
                            MaxSpeed = "201",
                            Range = "483",
                            Seats = 5,
                            PricePerDay = 100,
                            IsAvailable = true,
                            LocationId = 4,
                            OurCarImage = "/images/model-S.jpg"
                        },
                        new OurCars
                        {
                            Car = model3,
                            MaxSpeed = "261",
                            Range = "536",
                            Seats = 5,
                            PricePerDay = 110,
                            IsAvailable = true,
                            LocationId = 1,
                            OurCarImage = "/images/model-3.jpg"
                        },
                        new OurCars
                        {
                            Car = model3,
                            MaxSpeed = "261",
                            Range = "536",
                            Seats = 5,
                            PricePerDay = 110,
                            IsAvailable = true,
                            LocationId = 3,
                            OurCarImage = "/images/model-3.jpg"
                        },
                        new OurCars
                        {
                            Car = modelX,
                            MaxSpeed = "250",
                            Range = "588",
                            Seats = 5,
                            PricePerDay = 120,
                            IsAvailable = true,
                            LocationId = 2,
                            OurCarImage = "/images/tesla-X.jpg"
                        },
                        new OurCars
                        {
                            Car = modelX,
                            MaxSpeed = "250",
                            Range = "588",
                            Seats = 5,
                            PricePerDay = 120,
                            IsAvailable = true,
                            LocationId = 4,
                            OurCarImage = "/images/tesla-X.jpg"
                        },
                        new OurCars
                        {
                            Car = modelY,
                            MaxSpeed = "217",
                            Range = "425",
                            Seats = 5,
                            PricePerDay = 130,
                            IsAvailable = true,
                            LocationId = 1,
                            OurCarImage = "/images/photo-modelY.jpg"
                        },
                        new OurCars
                        {
                            Car = modelY,
                            MaxSpeed = "217",
                            Range = "425",
                            Seats = 5,
                            PricePerDay = 130,
                            IsAvailable = true,
                            LocationId = 4,
                            OurCarImage = "/images/photo-modelY.jpg"
                        },
                        new OurCars
                        {
                            Car = cybertruck,
                            MaxSpeed = "210",
                            Range = "514",
                            Seats = 5,
                            PricePerDay = 200,
                            IsAvailable = true,
                            LocationId = 2,
                            OurCarImage = "/images/2023_Tesla_Cybertruck.jpg"
                        },
                        new OurCars
                        {
                            Car = cybertruck,
                            MaxSpeed = "210",
                            Range = "514",
                            Seats = 5,
                            PricePerDay = 200,
                            IsAvailable = true,
                            LocationId = 3,
                            OurCarImage = "/images/2023_Tesla_Cybertruck.jpg"
                        },
                        new OurCars
                        {

                            Car = cybertruck,
                            MaxSpeed = "210",
                            Range = "514",
                            Seats = 5,
                            PricePerDay = 200,
                            IsAvailable = true,
                            LocationId = 3,
                            OurCarImage = "/images/2023_Tesla_Cybertruck.jpg"
                        },
                    };

                    _dbcontext.CarModel.AddRange(ourCars);
                    await _dbcontext.SaveChangesAsync();

                }
            }
        }
    }*/
}
