using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Context;
using Prueba.Models;
//Librerías agregadas
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Prueba.Helpers;

namespace Prueba.Controllers
{
    public class CochesController : Controller
    {
        private readonly Contexto_1 _context;
        //Instancia _config
        private readonly AzureStorageConfig _config = null;

        public CochesController(Contexto_1 context, IOptions<AzureStorageConfig>config)
        {
            _context = context;
            _config = config.Value;
        }

        // GET: Coches
        public async Task<IActionResult> Index()
        {
              return _context.Coche != null ? 
                          View(await _context.Coche.ToListAsync()) :
                          Problem("Entity set 'Contexto_1.Coche'  is null.");
        }

        // GET: Coches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coche == null)
            {
                return NotFound();
            }

            var coche = await _context.Coche
                .FirstOrDefaultAsync(m => m.Id_Coche_PK == id);
            if (coche == null)
            {
                return NotFound();
            }

            return View(coche);
        }

        // GET: Coches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Coche_PK,Matricula,Modelo,Color,Ano")] Coche coche)//, ICollection<IFormFile>archivo) //Agregado el ICollection
        {
            if (ModelState.IsValid)
            {
                //AQUÏ VA VAR FOTO
                _context.Add(coche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coche);
        }

        // GET: Coches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coche == null)
            {
                return NotFound();
            }

            var coche = await _context.Coche.FindAsync(id);
            if (coche == null)
            {
                return NotFound();
            }
            return View(coche);
        }

        // POST: Coches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Coche_PK,Matricula,Modelo,Color,Ano")] Coche coche)
        {
            if (id != coche.Id_Coche_PK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocheExists(coche.Id_Coche_PK))
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
            return View(coche);
        }

        // GET: Coches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coche == null)
            {
                return NotFound();
            }

            var coche = await _context.Coche
                .FirstOrDefaultAsync(m => m.Id_Coche_PK == id);
            if (coche == null)
            {
                return NotFound();
            }

            return View(coche);
        }

        // POST: Coches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coche == null)
            {
                return Problem("Entity set 'Contexto_1.Coche'  is null.");
            }
            var coche = await _context.Coche.FindAsync(id);
            if (coche != null)
            {
                _context.Coche.Remove(coche);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocheExists(int id)
        {
          return (_context.Coche?.Any(e => e.Id_Coche_PK == id)).GetValueOrDefault();
        }
    }
}
