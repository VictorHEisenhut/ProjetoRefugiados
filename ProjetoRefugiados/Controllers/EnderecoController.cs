using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoRefugiados.Data;
using ProjetoRefugiados.Models;

namespace ProjetoRefugiados.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index(string sortOrderNome, string sortOrderCidade, string searchStringNome, string searchStringCidade)
        {
            ViewBag.nomeSortParam = String.IsNullOrEmpty(sortOrderNome) ? "nome_desc" : "";
            ViewBag.cidadeSortParam = String.IsNullOrEmpty(sortOrderCidade) ? "cidade_desc" : "";

            var locais = from s in _context.Enderecos.ToList() select s;

            if (!String.IsNullOrEmpty(searchStringNome))
            {
                locais = locais.Where(s => s.Nome.Contains(searchStringNome) || s.Nome.Contains(searchStringNome));
            }
            if (!String.IsNullOrEmpty(searchStringCidade))
            {
                locais = locais.Where(s => s.Cidade.Contains(searchStringCidade) || s.Cidade.Contains(searchStringCidade));
            }
            switch (sortOrderNome)
            {
                case "nome_desc":
                    locais = locais.OrderByDescending(n => n.Nome);
                    break;
                default:
                    locais = locais.OrderBy(n => n.Nome);
                    break;
            }
            switch (sortOrderCidade)
            {
                case "cidade_desc":
                    locais = locais.OrderByDescending(n => n.Cidade);
                    break;
                default:
                    locais = locais.OrderBy(n => n.Cidade);
                    break;
            }
            return _context.Enderecos != null ? 
                          View(locais) :
                          Problem("Entity set 'AppDbContext.Enderecos'  is null.");
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email,Descricao,Cidade,Estado,Bairro,Rua,Numero,CEP")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,Descricao,Cidade,Estado,Bairro,Rua,Numero,CEP")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
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
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enderecos == null)
            {
                return Problem("Entity set 'AppDbContext.Enderecos'  is null.");
            }
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
          return (_context.Enderecos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
