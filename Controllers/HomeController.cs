using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HuertoDelValle.Data;
using HuertoDelValle.Models;

namespace HuertoDelValle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
// Esto es un coms una prueba
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Contactenos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contactenos(Contacto c){
            if(ModelState.IsValid){
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(c);
        }

        public IActionResult Feedback()
        {
            var Calificaciones = _context.DataCalificacion.ToList();
            return View(Calificaciones);
        }
        public IActionResult EliminarCalificacion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EliminarCalificacion(Calificacion c){
            if(ModelState.IsValid){
                _context.Remove(c);
                _context.SaveChanges();
                return RedirectToAction("Feedback","Home");
            }
            return View(c);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
