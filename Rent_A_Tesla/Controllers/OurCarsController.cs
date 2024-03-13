using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Rent_A_Tesla.Data;
using Rent_A_Tesla.Models;


namespace Rent_A_Tesla.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OurCarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public OurCarsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: OurCars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OurCars
                .Include(o => o.Car)
                .Include(o => o.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OurCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCars = await _context.OurCars
                .Include(o => o.Location)
                .Include(e => e.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourCars == null)
            {
                return NotFound();
            }

            return View(ourCars);
        }

        // GET: OurCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.CarModel, "Id", "Model");
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Name");
            return View();
        }

        // POST: OurCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,MaxSpeed,Range,Seats,PricePerDay,IsAvailable,LocationId")] OurCars ourCars, IFormFile? carImage)
        {
            if (ModelState.IsValid)
            {
                
                if (carImage != null && carImage.Length > 0) // Dodawanie zdjęcia samochodu
                {
                    var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(carImage.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await carImage.CopyToAsync(fileStream);
                    }

                    ourCars.OurCarImage = Path.Combine("images", fileName);
                }
                _context.Add(ourCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.CarModel, "Id", "Model", ourCars.CarId);
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Name", ourCars.LocationId);
            return View(ourCars);
        }

        // GET: OurCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCars = await _context.OurCars.FindAsync(id);
            if (ourCars == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Name", ourCars.LocationId);
            ViewData["CarId"] = new SelectList(_context.CarModel, "Id", "Model", ourCars.CarId);
            return View(ourCars);
        }

        // POST: OurCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,MaxSpeed,Range,Seats,PricePerDay,IsAvailable,LocationId")] OurCars ourCars, IFormFile carImage)
        {
            if (id != ourCars.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   
                    if (carImage != null && carImage.Length > 0) // Edycja zdjęcia
                    {
                        var fileName = Path.GetFileNameWithoutExtension(carImage.FileName);
                        var extension = Path.GetExtension(carImage.FileName);
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName + DateTime.Now.ToString("yymmssfff") + extension);

                        
                        var oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, ourCars.OurCarImage); // Usuwanie starego zdjęcia jeżeli istnieje
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await carImage.CopyToAsync(fileStream);
                        }
                        ourCars.OurCarImage = Path.Combine("images", fileName + DateTime.Now.ToString("yymmssfff") + extension);
                    }

                    _context.Update(ourCars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurCarsExists(ourCars.Id))
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
            ViewData["CarId"] = new SelectList(_context.CarModel, "Id", "Model", ourCars.CarId);
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Name", ourCars.LocationId);
            return View(ourCars);
        }

        // GET: OurCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCars = await _context.OurCars
                .Include(o => o.Location)
                .Include(e => e.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourCars == null)
            {
                return NotFound();
            }

            return View(ourCars);
        }

        // POST: OurCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourCars = await _context.OurCars.FindAsync(id);
            if (ourCars != null)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, ourCars.OurCarImage);  // Usuwanie zdjęcia
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.OurCars.Remove(ourCars);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurCarsExists(int id)
        {
            return _context.OurCars.Any(e => e.Id == id);
        }
    }
}
