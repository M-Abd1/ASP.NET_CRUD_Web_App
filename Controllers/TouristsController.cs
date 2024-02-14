using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bliss_Travels___Tours.Models;

namespace Bliss_Travels___Tours.Controllers
{
    public class TouristsController : Controller
    {
        private readonly TouristTravelsContext _context;

        public TouristsController(TouristTravelsContext context)
        {
            _context = context;
        }

        // GET: Tourists
        public async Task<IActionResult> Index()
        {
            var touristTravelsContext = _context.Tourists.Include(t => t.Tour);
            return View(await touristTravelsContext.ToListAsync());
        }

        // GET: Tourists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourist = await _context.Tourists
                .Include(t => t.Tour)
                .FirstOrDefaultAsync(m => m.TouristId == id);
            if (tourist == null)
            {
                return NotFound();
            }

            return View(tourist);
        }

        // GET: Tourists/Create
        public IActionResult Create()
        {
            ViewData["TourId"] = new SelectList(_context.TourManagers, "TourId", "TourId");
            return View();
        }

        // POST: Tourists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TouristId,Name,Email,PhoneNumber,Address,TourId")] Tourist tourist)
        {
            _context.Add(tourist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["TourId"] = new SelectList(_context.TourManagers, "TourId", "TourId", tourist.TourId);
            return View(tourist);
        }

        // GET: Tourists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourist = await _context.Tourists.FindAsync(id);
            if (tourist == null)
            {
                return NotFound();
            }
            ViewData["TourId"] = new SelectList(_context.TourManagers, "TourId", "TourId", tourist.TourId);
            return View(tourist);
        }

        // POST: Tourists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TouristId,Name,Email,PhoneNumber,Address,TourId")] Tourist tourist)
        {
            if (id != tourist.TouristId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(tourist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristExists(tourist.TouristId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            ViewData["TourId"] = new SelectList(_context.TourManagers, "TourId", "TourId", tourist.TourId);
            return View(tourist);
        }

        // GET: Tourists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourist = await _context.Tourists
                .Include(t => t.Tour)
                .FirstOrDefaultAsync(m => m.TouristId == id);
            if (tourist == null)
            {
                return NotFound();
            }

            return View(tourist);
        }

        // POST: Tourists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tourist = await _context.Tourists.FindAsync(id);
            if (tourist != null)
            {
                _context.Tourists.Remove(tourist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristExists(string id)
        {
            return _context.Tourists.Any(e => e.TouristId == id);
        }
    }
}
