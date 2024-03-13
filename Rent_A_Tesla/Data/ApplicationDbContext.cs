using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent_A_Tesla.Models;

namespace Rent_A_Tesla.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rent_A_Tesla.Models.CarModel> CarModel { get; set; } = default!;
        public DbSet<Rent_A_Tesla.Models.OurCars> OurCars { get; set; } = default!;
        public DbSet<Rent_A_Tesla.Models.Location> Location { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OurCars>(e =>
            {
                e.Property(e => e.PricePerDay).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Reservation>(e =>
            {
                e.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            });

            // Konfiguracja, aby zapobiec usuwaniu kaskadowemu w powiązaniach, które mogą powodować cykle lub wielokrotne ścieżki kaskadowe
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.PickupLocation)
                .WithMany()
                .HasForeignKey(r => r.PickupLocationId)
                .OnDelete(DeleteBehavior.Restrict); // Zmień strategię usuwania na Restrict dla PickupLocation

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ReturnLocation)
                .WithMany()
                .HasForeignKey(r => r.ReturnLocationId)
                .OnDelete(DeleteBehavior.Restrict); // Zmień strategię usuwania na Restrict dla ReturnLocation


        }
        public DbSet<Rent_A_Tesla.Models.Reservation> Reservation { get; set; } = default!;


    }
}
