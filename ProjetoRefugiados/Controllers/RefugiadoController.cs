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
    public class RefugiadoController : Controller
    {
        private readonly AppDbContext _context;


        public RefugiadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Refugiado
        public async Task<IActionResult> Index()
        {
             List<Refugiado> refugiados = _context.Refugiados.ToList();

            foreach (var refugiado in refugiados)
            {
                refugiado.Pais = _context.Paises.FirstOrDefault(p => p.Id == refugiado.PaisId);
            }
              

              return _context.Refugiados != null ? 
                          View(await _context.Refugiados.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Refugiados'  is null.");
        }

        // GET: Refugiado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Refugiados == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refugiado == null)
            {
                return NotFound();
            }
            refugiado.Pais = _context.Paises.FirstOrDefault(p => p.Id == refugiado.PaisId);

            return View(refugiado);
        }

        // GET: Refugiado/Create
        public IActionResult Create()
        {
            List<SelectListItem> Generos = new();
            Generos = Enum.GetValues(typeof(Genero)).Cast<Genero>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Generos = Generos;

            List<SelectListItem> EstadosCivis = new();
            EstadosCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.EstadosCivis = EstadosCivis;

            List<SelectListItem> Escolaridades = new();
            Escolaridades = Enum.GetValues(typeof(Escolaridade)).Cast<Escolaridade>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Escolaridades = Escolaridades;

            List<SelectListItem> Paises = new();
            Paises = _context.Paises.Select(c => new SelectListItem() { Text = c.Pais, Value = c.Id.ToString() }).ToList();
            ViewBag.Paises = Paises;

            return View();
        }

        // POST: Refugiado/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,Senha,DataNascimento,Telefone,EstadoCivil,Genero,Escolaridade,Pais")] Refugiado refugiado)
        {
            refugiado.Pais = _context.Paises.FirstOrDefault(p => p.Id == refugiado.Pais.Id);
            refugiado.PaisId = refugiado.Pais.Id;

           // if (ModelState.IsValid)
            {
                _context.Add(refugiado);
                await _context.SaveChangesAsync();
                return RedirectToRoute($"Documento/Create/{refugiado.Id}");
                //return RedirectToAction("Create", "Documento", $"Create/Documento/{refugiado.Id}");
            }
            return View(refugiado);
        }

        // GET: Refugiado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Generos = new();
            Generos = Enum.GetValues(typeof(Genero)).Cast<Genero>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Generos = Generos;

            List<SelectListItem> EstadosCivis = new();
            EstadosCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.EstadosCivis = EstadosCivis;

            List<SelectListItem> Escolaridades = new();
            Escolaridades = Enum.GetValues(typeof(Escolaridade)).Cast<Escolaridade>().Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();
            ViewBag.Escolaridades = Escolaridades;

            List<SelectListItem> Paises = new();
            Paises = _context.Paises.Select(c => new SelectListItem() { Text = c.Pais, Value = c.Id.ToString() }).ToList();
            ViewBag.Paises = Paises;

            if (id == null || _context.Refugiados == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiados.FindAsync(id);
            if (refugiado == null)
            {
                return NotFound();
            }

            return View(refugiado);
        }

        // POST: Refugiado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,Senha,DataNascimento,Telefone,EstadoCivil,Genero,Escolaridade")] Refugiado refugiado)
        {
            if (id != refugiado.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refugiado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefugiadoExists(refugiado.Id))
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
            return View(refugiado);
        }

        // GET: Refugiado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Refugiados == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refugiado == null)
            {
                return NotFound();
            }

            return View(refugiado);
        }

        // POST: Refugiado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Refugiados == null)
            {
                return Problem("Entity set 'AppDbContext.Refugiados'  is null.");
            }
            var refugiado = await _context.Refugiados.FindAsync(id);
            if (refugiado != null)
            {
                _context.Refugiados.Remove(refugiado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefugiadoExists(int id)
        {
          return (_context.Refugiados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
