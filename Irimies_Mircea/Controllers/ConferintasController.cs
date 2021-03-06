using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Irimies_Mircea.Data;
using Irimies_Mircea.Models;
using Microsoft.AspNetCore.Authorization;

namespace Irimies_Mircea.Controllers
{
    [Authorize(Policy = "OnlyAdministrators")]
    public class ConferintasController : Controller
    {
        private readonly TeamContext _context;

        public ConferintasController(TeamContext context)
        {
            _context = context;
        }

        // GET: Conferintas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conferintas.ToListAsync());
        }

        // GET: Conferintas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferinta = await _context.Conferintas
                .FirstOrDefaultAsync(m => m.ConferintaID == id);
            if (conferinta == null)
            {
                return NotFound();
            }

            return View(conferinta);
        }

        // GET: Conferintas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conferintas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConferintaID,nume_divizie")] Conferinta conferinta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conferinta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conferinta);
        }

        // GET: Conferintas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferinta = await _context.Conferintas.FindAsync(id);
            if (conferinta == null)
            {
                return NotFound();
            }
            return View(conferinta);
        }

        // POST: Conferintas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConferintaID,nume_divizie")] Conferinta conferinta)
        {
            if (id != conferinta.ConferintaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conferinta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferintaExists(conferinta.ConferintaID))
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
            return View(conferinta);
        }

        // GET: Conferintas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferinta = await _context.Conferintas
                .FirstOrDefaultAsync(m => m.ConferintaID == id);
            if (conferinta == null)
            {
                return NotFound();
            }

            return View(conferinta);
        }

        // POST: Conferintas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conferinta = await _context.Conferintas.FindAsync(id);
            _context.Conferintas.Remove(conferinta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConferintaExists(int id)
        {
            return _context.Conferintas.Any(e => e.ConferintaID == id);
        }
    }
}