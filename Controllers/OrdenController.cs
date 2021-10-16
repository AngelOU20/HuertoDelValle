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

        public IActionResult Create(Decimal id)
        {
            Orden Orden = new Orden();
            Orden.UserID = _userManager.GetUserName(User);
            Orden.montoTotal = id;

            return View(Orden);
        }

        [HttpPost]
        public IActionResult Pagar(Orden orden)
        {
            orden.PaymentDate = DateTime.Now;
             _context.Add(orden);
            _context.SaveChanges();
            ViewData["Message"] = "El pago se ha registrado";
            return View("Create");
        }

    }
}