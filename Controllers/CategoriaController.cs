using System.Linq;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace HuertoDelValle.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ApplicationDbContext _context;

        public CategoriaController(ILogger<CategoriaController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult AdministrarCategoria(){
            var categoria = _context.DataCategoria.Include(x => x.Productos).OrderBy(r => r.Id).ToList();
            return View(categoria);
        }

        public IActionResult AgregarCategoria(){
            return View();
        }

        [HttpPost]
        public IActionResult AgregarCategoria(Categoria c){
            if(ModelState.IsValid){
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("AdministrarCategoria");
            }
            return View(c);
        }

        public IActionResult EditarCategoria(int Id) {
            var categoria = _context.DataCategoria.Find(Id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult EditarCategoria(Categoria c) {
            if (ModelState.IsValid) {
                var categoria = _context.DataCategoria.Find(c.Id);  
                categoria.NombreCategoria = c.NombreCategoria;
                _context.SaveChanges();
                return RedirectToAction("AdministrarCategoria");
            }
            return View(c);
        }

        public IActionResult DetalleCategoria(int Id){
            var categoria = _context.DataCategoria.Find(Id);
            return View(categoria);
        }

        public IActionResult BorrarCategoria(int Id){
           
            var categoria= _context.DataCategoria.Find(Id);
            _context.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("AdministrarCategoria");
        }
    }
}