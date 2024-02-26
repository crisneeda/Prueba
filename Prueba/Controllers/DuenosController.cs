using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Context;
using Prueba.Models;
//Librerias agregadas
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Prueba.Helpers;

namespace Prueba.Controllers
{
    public class DuenosController : Controller
    {
        private readonly Contexto_1 _context;
        //Instancia _config
        private readonly AzureStorageConfig _config = null;

        public DuenosController(Contexto_1 context, IOptions<AzureStorageConfig> config)
        {
            _context = context;
            _config = config.Value;
        }

        // GET: Duenos
        public async Task<IActionResult> Index()
        {
              return _context.Dueno != null ? 
                          View(await _context.Dueno.ToListAsync()) :
                          Problem("Entity set 'Contexto_1.Dueno'  is null.");
        }

        // GET: Duenos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dueno == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id_duenos_PK == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // GET: Duenos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duenos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_duenos_PK,Nombre,Fecha_nac,Direccion,Curp")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Duenos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dueno == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            return View(dueno);
        }

        // POST: Duenos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_duenos_PK,Nombre,Fecha_nac,Direccion,Curp")] Dueno dueno)
        {
            if (id != dueno.Id_duenos_PK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoExists(dueno.Id_duenos_PK))
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
            return View(dueno);
        }

        // GET: Duenos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dueno == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id_duenos_PK == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // POST: Duenos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dueno == null)
            {
                return Problem("Entity set 'Contexto_1.Dueno'  is null.");
            }
            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno != null)
            {
                _context.Dueno.Remove(dueno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(int id)
        {
          return (_context.Dueno?.Any(e => e.Id_duenos_PK == id)).GetValueOrDefault();
        }
    }
}
