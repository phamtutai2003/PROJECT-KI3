using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POST.Areas.Personnel.Controllers;
using POST.Data;
using POST.Models;

namespace POST.Areas.Customer1.Controllers
{
    [Area("Customer1")]
    public class ShipmentsController : Controller
    {
        private readonly POSTContext _context;

        public ShipmentsController(POSTContext context)
        {
            _context = context;
        }

        // GET: Customer1/Shipments
        public async Task<IActionResult> Index()
        {
              return _context.Shipment != null ? 
                          View(await _context.Shipment.ToListAsync()) :
                          Problem("Entity set 'POSTContext.Shipment'  is null.");
        }

        // GET: Customer1/Shipments/Details/5
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

        // GET: Customer1/Shipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Shipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Infor,Date_Receive,Status,Delivered_By")] Shipment shipment)
        {
            if (true)
            {
                _context.Add(shipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipment);
        }

        // GET: Customer1/Shipments/Edit/5
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

        // POST: Customer1/Shipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Infor,Date_Receive,Status,Delivered_By")] Shipment shipment)
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

        // GET: Customer1/Shipments/Delete/5
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

        // POST: Customer1/Shipments/Delete/5
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
