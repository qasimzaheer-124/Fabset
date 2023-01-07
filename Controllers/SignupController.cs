using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fabset_project.Models;

namespace fabset_project.Controllers
{
    public class SignupController : Controller
    {
        private readonly DataDbContext _context;

        public SignupController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Signup
        public async Task<IActionResult> Index()
        {
              return View(await _context.Signup.ToListAsync());
        }

        // GET: Signup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Signup == null)
            {
                return NotFound();
            }

            var signup = await _context.Signup
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (signup == null)
            {
                return NotFound();
            }

            return View(signup);
        }

        // GET: Signup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Signup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Email,Password,Retype,Dof")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signup);
        }

        // GET: Signup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Signup == null)
            {
                return NotFound();
            }

            var signup = await _context.Signup.FindAsync(id);
            if (signup == null)
            {
                return NotFound();
            }
            return View(signup);
        }

        // POST: Signup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email,Password,Retype,Dof")] Signup signup)
        {
            if (id != signup.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignupExists(signup.UserId))
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
            return View(signup);
        }

        // GET: Signup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Signup == null)
            {
                return NotFound();
            }

            var signup = await _context.Signup
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (signup == null)
            {
                return NotFound();
            }

            return View(signup);
        }

        // POST: Signup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Signup == null)
            {
                return Problem("Entity set 'DataDbContext.Signup'  is null.");
            }
            var signup = await _context.Signup.FindAsync(id);
            if (signup != null)
            {
                _context.Signup.Remove(signup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignupExists(int id)
        {
          return _context.Signup.Any(e => e.UserId == id);
        }
    }
}
