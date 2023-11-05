using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendaLanches.Data;

namespace VendaLanches.Areas.Admin.Controllers
{   
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminEntregaController : Controller
    {
        readonly AppDbContext _context;

        public AdminEntregaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult List() 
        {   
            var entregas = _context.Entregas;

            return View(entregas);
        }

        public IActionResult Delete(int? id) 
        {
            if (!id.HasValue) return RedirectToAction("List");

            var entrega = _context.Entregas.Where(p => p.EntregaId == id).FirstOrDefault();

            if (entrega == null) return RedirectToAction("List");

            _context.Entry(entrega).State = EntityState.Deleted;

            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}