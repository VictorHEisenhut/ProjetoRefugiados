using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoRefugiados.Data;
using ProjetoRefugiados.Models;

namespace ProjetoRefugiados.Controllers
{
    public class ConsuladoController : Controller
    {
        private readonly AppDbContext _context;

        public ConsuladoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Consulado
        public async Task<IActionResult> Index()
        {
            List<Consulado> consulados = _context.Consulados.ToList();

            foreach (var consulado in consulados)
            {
                consulado.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == consulado.EnderecoId);
            }
            return _context.Consulados != null ?
                          View(await _context.Consulados.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Consulados'  is null.");
        }

        // GET: Consulado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consulados == null)
            {
                return NotFound();
            }

            var consulado = await _context.Consulados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulado == null)
            {
                return NotFound();
            }
            consulado.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == consulado.EnderecoId);

            return View(consulado);
        }

        // GET: Consulado/Create
        public IActionResult Create()
        {
            List<SelectListItem> Enderecos = new();
            Enderecos = _context.Enderecos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Enderecos = Enderecos;
            return View();
        }

        // POST: Consulado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco")] Consulado consulado)
        {
            consulado.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == consulado.Endereco.Id);
            consulado.EnderecoId = consulado.Endereco.Id;
            //if (ModelState.IsValid)
            {
                _context.Add(consulado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consulado);
        }

        // GET: Consulado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Enderecos = new();
            Enderecos = _context.Enderecos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Enderecos = Enderecos;
            if (id == null || _context.Consulados == null)
            {
                return NotFound();
            }

            var consulado = await _context.Consulados.FindAsync(id);
            if (consulado == null)
            {
                return NotFound();
            }
            return View(consulado);
        }

        // POST: Consulado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Endereco")] Consulado consulado)
        {
            if (id != consulado.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    consulado.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == consulado.Endereco.Id);
                    _context.Update(consulado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsuladoExists(consulado.Id))
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
            return View(consulado);
        }

        // GET: Consulado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consulados == null)
            {
                return NotFound();
            }

            var consulado = await _context.Consulados
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulado == null)
            {
                return NotFound();
            }

            return View(consulado);
        }

        // POST: Consulado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consulados == null)
            {
                return Problem("Entity set 'AppDbContext.Consulados'  is null.");
            }
            var consulado = await _context.Consulados.FindAsync(id);
            if (consulado != null)
            {
                _context.Consulados.Remove(consulado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsuladoExists(int id)
        {
          return (_context.Consulados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
