using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POST.Data;
using POST.Models;

namespace POST.Controllers
{
    public class DeliveredController : Controller
    {
        private readonly POSTContext _context;

        public DeliveredController(POSTContext context)
        {
            _context = context;
        }

        // GET: Delivered
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var Customer = from m in _context.Customer
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Customer = Customer.Where(s => s.Name!.Contains(searchString));
            }

            return View(await Customer.ToListAsync());
        }

        // GET: Delivered/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shipment == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // GET: Delivered/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Delivered/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Infor,Date_Receive,Status")] Shipment shipment)
        {
            if (true)
            {
                _context.Add(shipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipment);
        }

        // GET: Delivered/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shipment == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return View(shipment);
        }

        // POST: Delivered/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Infor,Date_Receive,Status")] Shipment shipment)
        {
            if (id != shipment.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(shipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipmentExists(shipment.Id))
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
            return View(shipment);
        }

        // GET: Delivered/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shipment == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // POST: Delivered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shipment == null)
            {
                return Problem("Entity set 'POSTContext.Shipment'  is null.");
            }
            var shipment = await _context.Shipment.FindAsync(id);
            if (shipment != null)
            {
                _context.Shipment.Remove(shipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipmentExists(int id)
        {
          return (_context.Shipment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
