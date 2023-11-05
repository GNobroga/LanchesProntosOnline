using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendaLanches.Data;
using VendaLanches.Models;

namespace VendaLanches.Areas.Admin.Controllers
{   
    [Area("Admin")] 
    [Authorize(Roles = "Admin")]
    public class AdminCategoriaController : Controller
    {   

        readonly AppDbContext _context;

        public AdminCategoriaController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult List() 
        { 
            var categorias = _context.Categorias.Where(c => !c.SoftDelete).OrderBy(c => c.CategoriaId);

            return View(categorias);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Categoria categoria) 
        {   
            if (!ModelState.IsValid) return View(categoria);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id) 
        {
            var categoria = _context.Categorias.Where(categoria => categoria.CategoriaId == id).FirstOrDefault();

            if (categoria == null) 
            {
                return RedirectToAction("Create");
            }

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Categoria categoria) 
        {

            Console.WriteLine("Entroia aqu");
            if (!ModelState.IsValid) return View(categoria);

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id) 
        {
           var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

           if (categoria == null) 
           {
                ViewBag.Error = "Não foi possível deletar";
                return RedirectToAction("List");
           }

            categoria.SoftDelete = true;
            
            _context.Entry(categoria).State = EntityState.Modified;

            _context.SaveChanges();

            ViewBag.Success = "Categoria deletada com sucesso.";
            return RedirectToAction("List");
        }
    }
}