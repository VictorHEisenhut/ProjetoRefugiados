using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoRefugiados.Data;
using ProjetoRefugiados.Models;
using ProjetoRefugiados.Models.Enums;

namespace ProjetoRefugiados.Controllers
{
    public class FilhosController : Controller
    {
        private readonly AppDbContext _context;

        public FilhosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Filhos
        public async Task<IActionResult> Index()
        {
            List<Filho> filhos = _context.Filhos.ToList();

            foreach (var filho in filhos)
            {
                filho.Pais = _context.Paises.FirstOrDefault(p => p.Id == filho.PaisId);
                filho.Parente = _context.Refugiados.FirstOrDefault(p => p.Id == filho.ParenteId);
            }
            return _context.Filhos != null ? 
                          View(await _context.Filhos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Filhos'  is null.");
        }

        // GET: Filhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filhos == null)
            {
                return NotFound();
            }

            var filho = await _context.Filhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filho == null)
            {
                return NotFound();
            }
            filho.Pais = _context.Paises.FirstOrDefault(p => p.Id == filho.PaisId);
            return View(filho);
        }

        // GET: Filhos/Create
        public IActionResult Create()
        {
            List<SelectListItem> Generos = new();
            Generos = Enum.GetValues(typeof(Genero)).Cast<Genero>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Generos = Generos;

            List<SelectListItem> Escolaridades = new();
            Escolaridades = Enum.GetValues(typeof(Escolaridade)).Cast<Escolaridade>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Escolaridades = Escolaridades;
        
            List<SelectListItem> Paises = new();
            Paises = _context.Paises.Select(c => new SelectListItem() { Text = c.Pais, Value = c.Id.ToString() }).ToList();
            ViewBag.Paises = Paises;

            List<SelectListItem> Parentes = new();
            Parentes = _context.Refugiados.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Parentes = Parentes;

            return View();
        }

        // POST: Filhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,DataNascimento,Genero,Escolaridade,Pais,Parente")] Filho filho)
        {

            filho.Pais = _context.Paises.FirstOrDefault(p => p.Id == filho.Pais.Id);
            filho.PaisId = filho.Pais.Id;
            filho.Parente = _context.Refugiados.FirstOrDefault(p => p.Id == filho.Parente.Id);
            filho.ParenteId = filho.Parente.Id;
            // if (ModelState.IsValid)
            {
            _context.Add(filho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filho);
        }

        // GET: Filhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            List<SelectListItem> Generos = new();
            Generos = Enum.GetValues(typeof(Genero)).Cast<Genero>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Generos = Generos;

            List<SelectListItem> Parentes = new();
            Parentes = _context.Refugiados.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Parentes = Parentes;

            List<SelectListItem> Escolaridades = new();
            Escolaridades = Enum.GetValues(typeof(Escolaridade)).Cast<Escolaridade>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Escolaridades = Escolaridades;

            List<SelectListItem> Paises = new();
            Paises = _context.Paises.Select(c => new SelectListItem() { Text = c.Pais, Value = c.Id.ToString() }).ToList();
            ViewBag.Paises = Paises;

            if (id == null || _context.Filhos == null)
            {
                return NotFound();
            }

            var filho = await _context.Filhos.FindAsync(id);
            if (filho == null)
            {
                return NotFound();
            }
            return View(filho);
        }

        // POST: Filhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,Senha,DataNascimento,Genero,Escolaridade,Pais")] Filho filho)
        {
            if (id != filho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilhoExists(filho.Id))
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
            return View(filho);
        }

        // GET: Filhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filhos == null)
            {
                return NotFound();
            }

            var filho = await _context.Filhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filho == null)
            {
                return NotFound();
            }

            return View(filho);
        }

        // POST: Filhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filhos == null)
            {
                return Problem("Entity set 'AppDbContext.Filhos'  is null.");
            }
            var filho = await _context.Filhos.FindAsync(id);
            if (filho != null)
            {
                _context.Filhos.Remove(filho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilhoExists(int id)
        {
          return (_context.Filhos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
