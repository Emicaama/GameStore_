using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class JuegosController : Controller
    {
        private readonly AppDbcontext _context;

        public JuegosController(AppDbcontext context)
        {
            _context = context;
        }

        // GET: Juegos
        public async Task<IActionResult> Index()
        {
            var appDbcontext = _context.Juegos.Include(j => j.Empresa).Include(j => j.Genero);
 
            return View(await appDbcontext.ToListAsync());
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var juegos = from s in _context.Juegos
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                juegos = juegos.Where(s => s.nombreJuego.Contains(searchString)
                                        || s.Empresa.nombreEmpresa.Contains(searchString)
                                        || s.Genero.nombreGenero.Contains(searchString));
            }

            return View(await juegos.AsNoTracking().ToListAsync());
        }

        // GET: Juegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Juegos == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .Include(j => j.Empresa)
                .Include(j => j.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // GET: Juegos/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "descripcion");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "descripcion");
            return View();
        }

        // POST: Juegos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,juegoFotoUrl,nombreJuego,descripcion,precio,fechaPublicacion,GeneroId,EmpresaId")] Juego juego)
        {
            _context.Add(juego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "descripcion", juego.EmpresaId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "descripcion", juego.GeneroId);
            return View(juego);
        }

        // GET: Juegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Juegos == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos.FindAsync(id);
            if (juego == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "descripcion", juego.EmpresaId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "descripcion", juego.GeneroId);
            return View(juego);
        }

        // POST: Juegos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,juegoFotoUrl,nombreJuego,descripcion,precio,fechaPublicacion,GeneroId,EmpresaId")] Juego juego)
        {
            if (id != juego.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(juego);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuegoExists(juego.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "descripcion", juego.EmpresaId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "descripcion", juego.GeneroId);
            return View(juego);
        }

        // GET: Juegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Juegos == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .Include(j => j.Empresa)
                .Include(j => j.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // POST: Juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Juegos == null)
            {
                return Problem("Entity set 'AppDbcontext.Juegos'  is null.");
            }
            var juego = await _context.Juegos.FindAsync(id);
            if (juego != null)
            {
                _context.Juegos.Remove(juego);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(int id)
        {
          return _context.Juegos.Any(e => e.Id == id);
        }
    }
}
