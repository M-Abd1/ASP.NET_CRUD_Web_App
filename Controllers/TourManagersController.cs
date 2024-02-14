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
    public class TourManagersController : Controller
    {
        private readonly TouristTravelsContext _context;

        public TourManagersController(TouristTravelsContext context)
        {
            _context = context;
        }

        // GET: TourManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TourManagers.ToListAsync());
        }

        // GET: TourManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourManager = await _context.TourManagers
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tourManager == null)
            {
                return NotFound();
            }

            return View(tourManager);
        }

        // GET: TourManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TourManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,StartingPosition,Destination,DepartureDate,ReturnDate,Description,CreatedAt")] TourManager tourManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tourManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourManager);
        }

        // GET: TourManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourManager = await _context.TourManagers.FindAsync(id);
            if (tourManager == null)
            {
                return NotFound();
            }
            return View(tourManager);
        }

        // POST: TourManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,StartingPosition,Destination,DepartureDate,ReturnDate,Description,CreatedAt")] TourManager tourManager)
        {
            if (id != tourManager.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourManagerExists(tourManager.TourId))
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
            return View(tourManager);
        }

        // GET: TourManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourManager = await _context.TourManagers
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tourManager == null)
            {
                return NotFound();
            }

            return View(tourManager);
        }

        // POST: TourManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourManager = await _context.TourManagers.FindAsync(id);
            if (tourManager != null)
            {
                _context.TourManagers.Remove(tourManager);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourManagerExists(int id)
        {
            return _context.TourManagers.Any(e => e.TourId == id);
        }
    }
}
