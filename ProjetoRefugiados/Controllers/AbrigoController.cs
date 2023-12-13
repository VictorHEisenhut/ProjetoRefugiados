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
    public class AbrigoController : Controller
    {
        private readonly AppDbContext _context;

        public AbrigoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Abrigo
        public async Task<IActionResult> Index()
        {
            List<Abrigo> abrigos = _context.Abrigos.ToList();

            foreach (var abrigo in abrigos)
            {
                abrigo.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == abrigo.EnderecoId);
            }
            return _context.Abrigos != null ? 
                          View(await _context.Abrigos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Abrigos'  is null.");
        }

        // GET: Abrigo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abrigos == null)
            {
                return NotFound();
            }

            var abrigo = await _context.Abrigos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abrigo == null)
            {
                return NotFound();
            }
            abrigo.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == abrigo.EnderecoId);

            return View(abrigo);
        }

        // GET: Abrigo/Create
        public IActionResult Create()
        {
            List<SelectListItem> Enderecos = new();
            Enderecos = _context.Enderecos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Enderecos = Enderecos;
            return View();
        }

        // POST: Abrigo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco")] Abrigo abrigo)
        {
            abrigo.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == abrigo.Endereco.Id);
            abrigo.EnderecoId = abrigo.Endereco.Id;
            //if (ModelState.IsValid)
            {
                _context.Add(abrigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abrigo);
        }

        // GET: Abrigo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Enderecos = new();
            Enderecos = _context.Enderecos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Enderecos = Enderecos;
            if (id == null || _context.Abrigos == null)
            {
                return NotFound();
            }

            var abrigo = await _context.Abrigos.FindAsync(id);
            if (abrigo == null)
            {
                return NotFound();
            }
            return View(abrigo);
        }

        // POST: Abrigo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Endereco")] Abrigo abrigo)
        {
            if (id != abrigo.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    abrigo.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == abrigo.Endereco.Id);
                    _context.Update(abrigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbrigoExists(abrigo.Id))
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
            return View(abrigo);
        }

        // GET: Abrigo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abrigos == null)
            {
                return NotFound();
            }

            var abrigo = await _context.Abrigos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abrigo == null)
            {
                return NotFound();
            }

            return View(abrigo);
        }

        // POST: Abrigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abrigos == null)
            {
                return Problem("Entity set 'AppDbContext.Abrigos'  is null.");
            }
            var abrigo = await _context.Abrigos.FindAsync(id);
            if (abrigo != null)
            {
                _context.Abrigos.Remove(abrigo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbrigoExists(int id)
        {
          return (_context.Abrigos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
