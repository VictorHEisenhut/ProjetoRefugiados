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
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cadastro
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Cadastros != null ? 
                          View(await _context.Cadastros.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Cadastros'  is null.");
        }

        // GET: Cadastro/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastro/Create
        [HttpGet]
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

        // POST: Cadastro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,Senha,DataNascimento,Telefone,EstadoCivil,Genero,Escolaridade, Pais")] Cadastro cadastro)
        {
            cadastro.Pais = _context.Paises.FirstOrDefault(p => p.Id == cadastro.Pais.Id);


            cadastro.Documento = new Documento() { Id = 1, Cpf = "12345678901"};
            cadastro.Filho = new CadastroFilho() { Id = 1, DataNascimento = DateTime.Now, Escolaridade = Escolaridade.EnsinoFundamentalIncompleto, Genero = Genero.Masculino, Nome = "Jamal", Pais = cadastro.Pais, Sobrenome = "Check" };
            /*if (ModelState.IsValid)
            {*/
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            return View(cadastro);
        }

        // GET: Cadastro/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,Senha,DataNascimento,Telefone,EstadoCivil,Genero,Escolaridade")] Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Id))
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
            return View(cadastro);
        }

        // GET: Cadastro/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastros == null)
            {
                return Problem("Entity set 'AppDbContext.Cadastros'  is null.");
            }
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastros.Remove(cadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
          return (_context.Cadastros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
