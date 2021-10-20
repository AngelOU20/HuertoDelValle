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

/*No se utiliza*/
namespace HuertoDelValle.Controllers
{
    public class OrdenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdenController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Procesar(Decimal Id)
        {
            Orden orden = new Orden();
            orden.UserID = _userManager.GetUserName(User);
            orden.MontoTotal = Id;



            return View(orden);
        }

        [HttpPost]
        public IActionResult Envio(Orden orden)
        {
            if(ModelState.IsValid){
                orden.PaymentDate = DateTime.Now;
                _context.Add(orden);
                _context.SaveChanges();
                ViewData["Message"] = "Metodo registrado";
                return View("Proforma","Proforma");
            }
            
            return View(orden);
    
        }

    }
}