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
    public class PostoDeSaudeController : Controller
    {
        private readonly AppDbContext _context;

        public PostoDeSaudeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PostoDeSaude
        public async Task<IActionResult> Index()
        {
            List<PostoDeSaude> postos = _context.PostosDeSaude.ToList();
            foreach (var posto in postos)
            {
                posto.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == posto.EnderecoId);
            }
            return _context.PostosDeSaude != null ? 
                          View(await _context.PostosDeSaude.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.PostosDeSaude'  is null.");
        }

        // GET: PostoDeSaude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostosDeSaude == null)
            {
                return NotFound();
            }

            var postoDeSaude = await _context.PostosDeSaude
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postoDeSaude == null)
            {
                return NotFound();
            }
            postoDeSaude.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == postoDeSaude.EnderecoId);

            return View(postoDeSaude);
        }

        // GET: PostoDeSaude/Create
        public IActionResult Create()
        {
            List<SelectListItem> Enderecos = new();
            Enderecos = _context.Enderecos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Enderecos = Enderecos;
            return View();
        }

        // POST: PostoDeSaude/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco")] PostoDeSaude postoDeSaude)
        {
            postoDeSaude.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == postoDeSaude.Endereco.Id);
            postoDeSaude.EnderecoId = postoDeSaude.Endereco.Id;
            //if (ModelState.IsValid)
            {
                _context.Add(postoDeSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postoDeSaude);
        }

        // GET: PostoDeSaude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Enderecos = new();
            Enderecos = _context.Enderecos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Enderecos = Enderecos;
            if (id == null || _context.PostosDeSaude == null)
            {
                return NotFound();
            }

            var postoDeSaude = await _context.PostosDeSaude.FindAsync(id);
            if (postoDeSaude == null)
            {
                return NotFound();
            }
            return View(postoDeSaude);
        }

        // POST: PostoDeSaude/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Endereco")] PostoDeSaude postoDeSaude)
        {

            if (id != postoDeSaude.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    postoDeSaude.Endereco = _context.Enderecos.FirstOrDefault(p => p.Id == postoDeSaude.Endereco.Id);
                    _context.Update(postoDeSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoDeSaudeExists(postoDeSaude.Id))
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
            return View(postoDeSaude);
        }

        // GET: PostoDeSaude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostosDeSaude == null)
            {
                return NotFound();
            }

            var postoDeSaude = await _context.PostosDeSaude
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postoDeSaude == null)
            {
                return NotFound();
            }

            return View(postoDeSaude);
        }

        // POST: PostoDeSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostosDeSaude == null)
            {
                return Problem("Entity set 'AppDbContext.PostosDeSaude'  is null.");
            }
            var postoDeSaude = await _context.PostosDeSaude.FindAsync(id);
            if (postoDeSaude != null)
            {
                _context.PostosDeSaude.Remove(postoDeSaude);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostoDeSaudeExists(int id)
        {
          return (_context.PostosDeSaude?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
