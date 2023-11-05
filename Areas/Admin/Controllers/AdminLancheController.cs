using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VendaLanches.Data;
using VendaLanches.Models;

namespace VendaLanches.Areas.Admin.Controllers
{   
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLancheController : Controller
    {   

        readonly AppDbContext _context;

        public AdminLancheController(AppDbContext context) => _context = context; 
        public ViewResult List() 
        {   
            var lanches = _context.Lanches;

            return View(lanches);
        }

        public ViewResult Create() 
        {
            // Eu deveria criar um ViewModel, mas vou fazer gambiarra

            ViewBag.Categorias = _context.Categorias.Where(c => !c.SoftDelete);

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Lanche lanche) 
        {   
            ViewBag.Categorias = _context.Categorias.Where(c => !c.SoftDelete);

            if (!ModelState.IsValid) return View(lanche);

            _context.Lanches.Add(lanche);

            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id) 
        {
            if (!id.HasValue) return RedirectToAction("List"); 

            var lanche = _context.Lanches.Where(l => l.LancheId == id).FirstOrDefault();

            _context.Entry(lanche).State = EntityState.Deleted;

            _context.SaveChanges();

            return RedirectToAction("List"); 
        }


         public IActionResult Edit(int? id) 
        {
            if (!id.HasValue) return RedirectToAction("List"); 

            var lanche = _context.Lanches.Where(l => l.LancheId == id).FirstOrDefault();
            ViewBag.Categorias = _context.Categorias.Where(c => !c.SoftDelete);
            
            return View(lanche);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Lanche lanche) 
        {
            
            if(!ModelState.IsValid) 
            {
                ViewBag.Categorias = _context.Categorias.Where(c => !c.SoftDelete);
                return View(lanche);
            }

            _context.Entry(lanche).State = EntityState.Modified;

            _context.SaveChanges();

            return RedirectToAction("List");
        
        }


    }
}