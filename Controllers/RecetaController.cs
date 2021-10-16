using System.Linq;
using System.Threading.Tasks;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HuertoDelValle.Controllers
{
    public class RecetaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RecetaController(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Recetas(){
            var recetas = from o in _context.DataReceta select o;
            return View(await recetas.ToListAsync());
        }

        public async Task<IActionResult> Receta(int? Id){
            Receta objProduct = await _context.DataReceta.FindAsync(Id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public IActionResult AdministrarReceta(){
            var recetas = _context.DataReceta.OrderBy(r => r.Id).ToList();
            return View(recetas);
        }

        public IActionResult RegistrarReceta(){
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarReceta(Receta r){
            if(ModelState.IsValid){
                _context.Add (r);
                _context.SaveChanges();
                return RedirectToAction("AdministrarReceta");
            }
            
            return View(r);
        }



    }
}