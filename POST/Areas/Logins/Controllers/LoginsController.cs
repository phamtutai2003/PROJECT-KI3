using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POST.Data;
using POST.Models;

namespace POST.Areas.Logins.Controllers
{
    [Area("Logins")]
    public class LoginsController : Controller
    {
        private readonly POSTContext _context;

        public LoginsController(POSTContext context)
        {
            _context = context;
        }

        // GET: logins
        public async Task<IActionResult> Index()
        {
            return _context.Login != null ?
                        View(await _context.Login.ToListAsync()) :
                        Problem("Entity set 'POSTContext.login'  is null.");
        }

        // GET: logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: logins/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,username,password")] Login login)
        {
            if (true)
            {
                var query = from p in _context.Personnel
                            join l in _context.Login on p.UserName equals l.username
                            where l.username == login.username && l.password == login.password
                            join m in _context.Customer on p.UserName equals m.UserName
                            select new
                            {
                                Personnel = p,
                                Login = l,
                                Customer = m
                            };

                var account = query.FirstOrDefault();
                if (account == null)
                {
                    return NotFound();
                }
                await _context.SaveChangesAsync();
                if (account.Personnel.UserName != null)
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home", new { area = "Persionnel" });
                }
                else if (account.Customer.UserName != null)
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
            }
            return View(login);
        }

        // GET: logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }


        public IActionResult Login()
        {
            return View();
        }

        //Login for account
        [HttpPost]
        [ValidateAntiForgeryToken]
       

        // POST: logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        public async Task<IActionResult> Edit(int id, [Bind("Id,username,password")] Login login)
        {
            if (id != login.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!loginExists(login.Id))
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
            return View(login);
        }

        // GET: logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Login == null)
            {
                return Problem("Entity set 'POSTContext.login'  is null.");
            }
            var login = await _context.Login.FindAsync(id);
            if (login != null)
            {
                _context.Login.Remove(login);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loginExists(int id)
        {
            return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
