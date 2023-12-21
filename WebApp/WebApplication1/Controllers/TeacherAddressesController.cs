using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TeacherAddressesController : Controller
    {
        private readonly WebAppContext _context;

        public TeacherAddressesController(WebAppContext context)
        {
            _context = context;
        }

        // GET: TeacherAddresses
        public async Task<IActionResult> Index()
        {
            var webAppContext = _context.TeacherAddresses.Include(t => t.Teacher);
            return View(await webAppContext.ToListAsync());
        }

        // GET: TeacherAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherAddresses == null)
            {
                return NotFound();
            }

            var teacherAddress = await _context.TeacherAddresses
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherAddressId == id);
            if (teacherAddress == null)
            {
                return NotFound();
            }

            return View(teacherAddress);
        }

        // GET: TeacherAddresses/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
            return View();
        }

        // POST: TeacherAddresses/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherAddressId,Street,City,Name")] TeacherAddress teacherAddress)
        {
            
            _context.Add(teacherAddress);
                await _context.SaveChangesAsync();
               
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherAddress.TeacherId);
            return View(teacherAddress);
        }

        // GET: TeacherAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherAddresses == null)
            {
                return NotFound();
            }

            var teacherAddress = await _context.TeacherAddresses.FindAsync(id);
            if (teacherAddress == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherAddress.TeacherId);
            return View(teacherAddress);
        }

        // POST: TeacherAddresses/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherAddressId,Street,City,TeacherId")] TeacherAddress teacherAddress)
        {
            if (id != teacherAddress.TeacherAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherAddressExists(teacherAddress.TeacherAddressId))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherAddress.TeacherId);
            return View(teacherAddress);
        }

        // GET: TeacherAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherAddresses == null)
            {
                return NotFound();
            }

            var teacherAddress = await _context.TeacherAddresses
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherAddressId == id);
            if (teacherAddress == null)
            {
                return NotFound();
            }

            return View(teacherAddress);
        }

        // POST: TeacherAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherAddresses == null)
            {
                return Problem("Entity set 'WebAppContext.TeacherAddresses'  is null.");
            }
            var teacherAddress = await _context.TeacherAddresses.FindAsync(id);
            if (teacherAddress != null)
            {
                _context.TeacherAddresses.Remove(teacherAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherAddressExists(int id)
        {
          return (_context.TeacherAddresses?.Any(e => e.TeacherAddressId == id)).GetValueOrDefault();
        }
    }
}
