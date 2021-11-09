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
    public class ReseñaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _um;
        private SignInManager<IdentityUser> _sim;
        public ReseñaController(ApplicationDbContext context, UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            _context = context;
            _um = um;
            _sim = sim;
        }

        public IActionResult AgregarReseña(int? rece)
        {
            if(rece == null)
            {
                return NotFound();
            }
            var resena = _context.DataReceta.Find(rece);
            var inforece = _context.DataReseña.Find(rece);
            // var infopeli2 = _context.Reseñas.Include(x=> x.Pelicula).Include(y=> y.Usuario).SingleOrDefault(z=> z.Pelicula.ID == peli);
            ViewBag.imgReceta = resena.Imagen;
            ViewBag.nomReceta = resena.NombreReceta;
            return View();
        }
        [HttpPost]
        public IActionResult AgregarReseña(int rece, Reseña objResena)
        {
            var resena = _context.DataReceta.Find(rece);

            ViewBag.imgReceta = resena.Imagen;
            ViewBag.nomReceta = resena.NombreReceta;
            
            if(ModelState.IsValid)
            {
                objResena.Fecha = System.DateTime.Now;
                objResena.RecetaId = rece;
                objResena.UserId = _um.GetUserName(User);
                // return BadRequest(objResena);
                _context.Add(objResena);
                _context.SaveChanges();
                return RedirectToAction("Recetas","Receta");
            }
            return View();
        }
        public IActionResult VerReseñas(int rece)
        {
            var listaResenas = _context.DataReseña.Include(q=>q.Receta).Where(p=>p.RecetaId.Equals(rece)).OrderBy(x=>x.Id).ToList();
            var receta = _context.DataReceta.Find(rece);
            ViewBag.rece = receta.NombreReceta;
            return View(listaResenas);
        }

        public IActionResult AdministrarReseñas(int rece)
        {
            var listaResenas = _context.DataReseña.Include(q=>q.Receta).Where(p=>p.RecetaId.Equals(rece)).OrderBy(x=>x.Id).ToList();
            var receta = _context.DataReceta.Find(rece);
            ViewBag.rece = receta.NombreReceta;
            return View(listaResenas);
        }

        public IActionResult eliminarReseña(int Id){
            var reseña= _context.DataReseña.Find(Id);
            _context.Remove(reseña);
            _context.SaveChanges();
            return RedirectToAction("AdministrarReceta","Receta");
        }


    }


}