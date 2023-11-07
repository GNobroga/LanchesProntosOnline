using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.ObjectPool;
using VendaLanches.Data;
using VendaLanches.Models;

namespace VendaLanches.Components
{
    public class Pagination : ViewComponent
    {
        private AppDbContext _context;

        public Pagination(AppDbContext context) => _context = context;

        public IViewComponentResult Invoke()
        {   
            int size = 2;
            int currentPage = 1;
            int currentLimit = 2;

            string queryPage = HttpContext.Request.Query["page"].ToString();

            string queryLimit = HttpContext.Request.Query["limit"].ToString();

            string queryCid = HttpContext.Request.Query["cid"].ToString();

            string querySearchString = HttpContext.Request.Query["searchString"].ToString();

            var existsQueryPage = !string.IsNullOrEmpty(queryPage) && Regex.Match(queryPage, @"\d+").Success;

            var existsQueryLimit = !string.IsNullOrEmpty(queryLimit) && Regex.Match(queryLimit, @"\d+").Success;

            if (existsQueryPage) currentPage = Convert.ToInt32(queryPage);

            if (existsQueryLimit) currentLimit = Convert.ToInt32(queryLimit);

            int cid = -1;

            var lanches = _context.Lanches.AsQueryable();

            if (!string.IsNullOrEmpty(queryCid) && Regex.Match(queryCid, @"\d+").Success)
            {
                cid = Convert.ToInt32(queryCid);
                
                if (cid != -1) lanches = lanches.Where(l => l.CategoriaId == cid);
            }


            if (!string.IsNullOrEmpty(querySearchString)) 
            {
                lanches = lanches.Where(l => l.Nome.ToLower().Equals(querySearchString.ToLower()));
            }

            lanches = lanches.Skip(size * currentPage).Take(currentLimit);
   
            ViewBag.HasNext = lanches.Count() > 0;

            ViewBag.HasPrevious = currentPage > 1;

            ViewBag.HasNext = lanches.Count() > 0;

            ViewBag.HasPrevious = currentPage > 1;
                
            return View(new {
                Page = currentPage,
                Limit = currentLimit,
                Cid = cid
            });
        }

    }
}