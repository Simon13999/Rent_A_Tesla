using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Tesla.Data;
using Rent_A_Tesla.Models;

namespace Rent_A_Tesla.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            IQueryable<Reservation> applicationDbContext = _context.Reservation.Include(r => r.Car).Include(r => r.PickupLocation).Include(r => r.ReturnLocation);

            if (!isAdmin)
            {
                // Dla zwykłych użytkowników, zwróć tylko ich rezerwacje
                applicationDbContext = applicationDbContext.Where(u => u.UserId == user.Id);
            }

            return _context.Reservation != null ?
                View(await applicationDbContext.ToListAsync()):
                Problem("Entity set 'ApplicationDbContext.MyNotes'  is null.");

            /*var applicationDbContext = _context.Reservation.Include(r => r.Car).Include(r => r.PickupLocation).Include(r => r.ReturnLocation);
            return _context.Reservation != null ? 
                View(await applicationDbContext.Where(u => u.UserId == user.Id).Include(s => s.User).ToListAsync()):
                Problem("Entity set 'ApplicationDbContext.MyNotes'  is null.");*/
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Car)
                .Include(r => r.PickupLocation)
                .Include(r => r.ReturnLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            var carsImage = _context.OurCars.Select(c => new
            {
                Id = c.Id,
                Image = c.OurCarImage
            }).ToList();

            ViewData["CarId"] = new SelectList(carsImage, "Id", "Image");
            ViewData["PickupLocationId"] = new SelectList(_context.Location, "Id", "Name");
            ViewData["ReturnLocationId"] = new SelectList(_context.Location, "Id", "Name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,PickupLocationId,ReturnLocationId,CarId,StartRes,EndRes,Amount")] Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.UserId = user.Id;

            if (ModelState.IsValid)
            {
                _context.Add(reservation);

                // Aktualizacja info o aucie i zmiana jego lok na lok zwrotu
                var car = await _context.OurCars.FindAsync(reservation.CarId);
                if (car != null)
                {
                    car.LocationId = reservation.ReturnLocationId; 
                    _context.Update(car);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.OurCars, "Id", "Id", reservation.CarId);
            ViewData["PickupLocationId"] = new SelectList(_context.Location, "Id", "Name", reservation.PickupLocationId);
            ViewData["ReturnLocationId"] = new SelectList(_context.Location, "Id", "Name", reservation.ReturnLocationId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.OurCars, "Id", "Id", reservation.CarId);
            ViewData["PickupLocationId"] = new SelectList(_context.Location, "Id", "Name", reservation.PickupLocationId);
            ViewData["ReturnLocationId"] = new SelectList(_context.Location, "Id", "Name", reservation.ReturnLocationId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,PickupLocationId,ReturnLocationId,CarId,StartRes,EndRes,Amount")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reservation.Date = DateTime.UtcNow; // ustawienie daty rezerwacji bez ingerencji klienta
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.OurCars, "Id", "Id", reservation.CarId);
            ViewData["PickupLocationId"] = new SelectList(_context.Location, "Id", "Name", reservation.PickupLocationId);
            ViewData["ReturnLocationId"] = new SelectList(_context.Location, "Id", "Name", reservation.ReturnLocationId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Car)
                .Include(r => r.PickupLocation)
                .Include(r => r.ReturnLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> GetPricePerDay(int carId)
        {
            var car = await _context.OurCars.FindAsync(carId);
            if (car != null)
            {
                return Json(car.PricePerDay);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarsByLocation(int locationId, DateTime startRes, DateTime endRes)
        {
            // Tylko auta które są dostępne w danej lokalizacji 
            var availableCars = await _context.OurCars
                .Where(c => c.LocationId == locationId)
                .Where(c => !_context.Reservation.Any(r => r.CarId == c.Id && r.EndRes > startRes && r.StartRes < endRes))
                .Select(c => new { c.Id, Model = c.Car.Model })
                .GroupBy(c => c.Model) // Wyświetlanie jednego auta w danym modelu (zakładamy, że wszystkie auta są identyczne)
                .Select(g => g.FirstOrDefault())
                .ToListAsync();

            return Json(availableCars);
        }

        private async Task UpdateCarLocationAndAvailability(int carId, int returnLocationId)
        {
            var car = await _context.OurCars.FindAsync(carId);
            if (car != null)
            {
                car.LocationId = returnLocationId;
                car.IsAvailable = true; // Auto staje się dostępne od razu po zakończeniu rezerwacji (liczymy na klientów, którzy oddają czyste i zatankowane auto)
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
