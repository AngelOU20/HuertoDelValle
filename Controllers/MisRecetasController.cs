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

namespace HuertoDelValle.Controllers
{
    public class MisRecetasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MisRecetasController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Proforma
        public async Task<IActionResult> MisRecetas()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataMisRecetas select o;
            items = items.
                Include(p => p.Receta).
                Where(s => s.UserID.Equals(userID));
            
            return View(await items.ToListAsync());
        }

        public IActionResult QuitarReceta(int id) 
        {
            var receta= _context.DataMisRecetas.Find(id);
            _context.Remove(receta);
            _context.SaveChanges();
            return RedirectToAction("MisRecetas");
        }

       
        
    }
}