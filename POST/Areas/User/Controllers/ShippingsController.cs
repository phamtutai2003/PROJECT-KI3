using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POST.Data;
using POST.Models;
using Microsoft.AspNetCore.Hosting;

namespace POST.Areas.User.Controllers
{
    [Area("User")]
    public class ShippingsController : Controller
    {
        private readonly POSTContext _context;

        public ShippingsController(POSTContext context)
        {
            _context = context;
        }

        // GET: User/Shippings
        public async Task<IActionResult> Index()
        {
              return _context.Shipping != null ? 
                          View(await _context.Shipping.ToListAsync()) :
                          Problem("Entity set 'POSTContext.Shipping'  is null.");
        }

        // GET: User/Shippings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shipping == null)
            {
                return NotFound();
            }

            var shipping = await _context.Shipping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: User/Shippings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Shippings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Origin,Id,Destination,DeliveryOption,Description,Weight,Shipping_Category,Image_Path")] Shipping shipping)
        {
            if (true)
            {
                var file = Request.Form.Files.FirstOrDefault();
                if (file != null && file.Length > 0)
                {
                    // Save the uploaded file to the server
                    var filePath = Path.Combine("wwwroot/images",  file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Set the Image_Path property to the file path of the uploaded image
                    shipping.Image_Path =   file.FileName;
                }

                _context.Add(shipping);
                await _context.SaveChangesAsync(); // wait for changes to be saved to the database
                Shipment shipment = new Shipment();
                shipment.Id = shipping.Id;
                shipment.Infor = "Customer";
                shipment.Date_Receive = DateTime.Now;
                shipment.Status = true;
                shipment.Delivered_By = shipping.Description;
                _context.Add(shipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipping);
        }


        // GET: User/Shippings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shipping == null)
            {
                return NotFound();
            }

            var shipping = await _context.Shipping.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return View(shipping);
        }

        // POST: User/Shippings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Origin,Id,Destination,DeliveryOption,Description,Weight,Shipping_Category,Image_Path")] Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(shipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingExists(shipping.Id))
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
            return View(shipping);
        }

        // GET: User/Shippings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shipping == null)
            {
                return NotFound();
            }

            var shipping = await _context.Shipping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // POST: User/Shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shipping == null)
            {
                return Problem("Entity set 'POSTContext.Shipping'  is null.");
            }
            var shipping = await _context.Shipping.FindAsync(id);
            if (shipping != null)
            {
                _context.Shipping.Remove(shipping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingExists(int id)
        {
          return (_context.Shipping?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
