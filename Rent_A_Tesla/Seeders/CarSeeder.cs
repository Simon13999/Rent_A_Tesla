using Rent_A_Tesla.Data;
using Rent_A_Tesla.Models;

namespace Rent_A_Tesla.Seeders
{
    public class CarSeeder
    {
        private readonly ApplicationDbContext _dbcontext;
        public CarSeeder(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Seed()
        {
            if (await _dbcontext.Database.CanConnectAsync())
            {
                if (!_dbcontext.CarModel.Any())
                {
                    var cars = new[]
                    {
                        new CarModel
                        {
                            Model = "Model S",
                            Description = "Model S jest stylizowanym na coupé połączeniem luksusowej limuzyny z liftbackiem.",
                            Production = "2015",
                            BodyStyle = "5-door liftback sedan",
                            Seats = "5",
                            CarImage = "/images/cars/tesla-6162269_640.jpg"
                        },
                        new CarModel
                        {
                            Model = "Model 3",
                            Description = "Model 3 zapewnia wystarczająco dużo miejsca, aby mogło w nim komfortowo podróżować 5 osób.",
                            Production = "2018",
                            BodyStyle = "4-door sedan",
                            Seats = "5",
                            CarImage = "/images/cars/tesla-5937063_640.jpg"
                        },
                        new CarModel
                        {
                            Model = "Model X",
                            Description = "Model X powstał na bazie Modelu S, dzieląc z nim deskę rozdzielczą i wiele elementów wnętrza.",
                            Production = "2017",
                            BodyStyle = "5-door SUV",
                            Seats = "5",
                            CarImage = "/images/cars/tesla-4311968_960_720.jpg"
                        },
                        new CarModel
                        {
                            Model = "Model Y",
                            Description = "Model Y bazuje na Modelu 3 z drzwiami typu falcon-wing jak w Tesli Model X.",
                            Production = "2021",
                            BodyStyle = "5-door SUV",
                            Seats = "5",
                            CarImage = "/images/cars/Tesla_Model_Y.jpg"
                        },
                        new CarModel
                        {
                            Model = "Model Cybertruck",
                            Description = "Model Cybertruck to duży pickup o mocnym napędzie elektrycznym.",
                            Production = "2023",
                            BodyStyle = "4-drzwiowy pickup",
                            Seats = "5",
                            CarImage = "/images/cars/Tesla_Cybertruck.jpg"
                        },
                    };

                    _dbcontext.CarModel.AddRange(cars);
                    await _dbcontext.SaveChangesAsync();

                }
            }
        }

    }
}
