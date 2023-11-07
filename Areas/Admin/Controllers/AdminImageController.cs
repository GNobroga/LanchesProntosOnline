using Microsoft.AspNetCore.Mvc;

namespace VendaLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminImageController : Controller
    {   

        public ViewResult List() 
        {

            var dir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "lanches"));
            
            return View(dir.GetFiles());
        }

        public ViewResult UploadFile() => View();

        [HttpPost]
        public IActionResult UploadFile([FromForm] IFormFile file) 
        {
            
            var allowExtensions = new string[] {".jpg", ".png", ".jpeg"};

            if (file == null)
            {
                ViewBag.FileError = "Arquivo não foi enviado";
                return View();
            }


            int contains = 0;

            foreach (var extension in allowExtensions)
            {
                if (file.FileName.Contains(extension)) 
                    contains++;
            }

            if (contains == 0) 
            {
                ViewBag.FileError = "Arquivo não suportado";
                return View();
            }
            
            
            var currentDir = Directory.GetCurrentDirectory();
            var dist = Path.Combine(currentDir, "wwwroot", "images", "lanches", file.FileName);

            using FileStream fs = new(dist, FileMode.Create, FileAccess.Write);

            file.CopyTo(fs);

            fs.Flush();

            return View();
        }
    }
}