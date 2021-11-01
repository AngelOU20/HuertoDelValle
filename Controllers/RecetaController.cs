using System;
using System.Linq;
using System.Threading.Tasks;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HuertoDelValle.Controllers
{
    public class RecetaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public RecetaController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager){
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Recetas(){
            var recetas = from o in _context.DataReceta select o;
            return View(await recetas.ToListAsync());
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

        public IActionResult EditarReceta(int Id) {
            var receta = _context.DataReceta.Find(Id);
            return View(receta);
        }

        [HttpPost]
        public IActionResult EditarReceta(Receta r){
            if(ModelState.IsValid){
                var receta = _context.DataReceta.Find(r.Id);  
                receta.NombreReceta = r.NombreReceta;
                receta.Imagen = r.Imagen;
                receta.DescripcionReceta = r.DescripcionReceta;
                receta.Ingrediente = r.Ingrediente;
                receta.Preparacion = r.Preparacion;
                _context.SaveChanges();
                return RedirectToAction("AdministrarReceta");
            }
            
            return View(r);
        }

        public IActionResult EliminarReceta(int Id) 
        {
            var receta= _context.DataReceta.Find(Id);
            _context.Remove(receta);
            _context.SaveChanges();
            return RedirectToAction("AdministrarReceta");
        }

        /*
        public async Task<IActionResult> Receta(int? Id){
            Receta objProduct = await _context.DataReceta.FindAsync(Id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }*/

        public IActionResult Receta(int? id)
        {
            var receta = _context.DataReceta.Find(id);
            var userID = _userManager.GetUserName(User);

            ViewBag.resenas = false;
            if (_context.DataReseña.Where(x => x.RecetaId.Equals(id)).Count() > 0)
            {
                ViewBag.resenas = true;
                Random rnd = new Random();
                int nrouser = rnd.Next(_context.DataReseña.Where(x=>x.RecetaId.Equals(id)).OrderBy(x=>x.Id).ToList().First().Id,_context.DataReseña.Where(x=>x.RecetaId.Equals(id)).OrderBy(x => x.Id).ToList().Last().Id);
                ViewBag.fecha = _context.DataReseña.Find(nrouser).Fecha.ToString();
                ViewBag.calificacion = _context.DataReseña.Where(x=>x.RecetaId.Equals(id)).FirstOrDefault(x=>x.Id.Equals(nrouser)).Calificacion;
                ViewBag.nombreusuario = _userManager.GetUserName(User);
                ViewBag.resenausuario = _context.DataReseña.Where(x=>x.RecetaId.Equals(id)).FirstOrDefault(x=>x.Id.Equals(nrouser)).Comentario;
                ViewBag.fecha = _context.DataReseña.Where(x=>x.RecetaId.Equals(id)).FirstOrDefault(x=>x.Id.Equals(nrouser)).Fecha;
            }
            if(receta == null){
                return NotFound();
            }
            return View(receta);
        }

    }
}