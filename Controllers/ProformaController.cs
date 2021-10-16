using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace HuertoDelValle.Controllers
{
    public class ProformaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Proforma
        public async Task<IActionResult> Proforma()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataProforma select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            var elements = await items.ToListAsync();
            var total = elements.Sum(c => c.Cantidad * c.Precio );
            
            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.proformas = elements;
            return View(model);
        }
        

        public IActionResult QuitarProducto(int id) 
        {
            var Producto= _context.DataProforma.Find(id);
            _context.Remove(Producto);
            _context.SaveChanges();
            return RedirectToAction("Proforma");
        }

        public IActionResult EditarCantidad(int id){
            var proforma = _context.DataProforma.Find(id);
            return View(proforma);
        }

        public IActionResult Procesar(){
            return View();
        }

        [HttpPost]
        public IActionResult EditarCantidad(Proforma p){
            if(ModelState.IsValid){
                var proforma = _context.DataProforma.Find(p.Id);
                proforma.Cantidad = p.Cantidad;
                proforma.SubTotal = p.Cantidad * proforma.Precio;
                _context.SaveChanges();
                return RedirectToAction("Proforma");
            }
            return View(p);
        }

        
    }

}