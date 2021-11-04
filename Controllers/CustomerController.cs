using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using HuertoDelValle.Models;
using HuertoDelValle.Data;
using Microsoft.EntityFrameworkCore;
using HuertoDelValle.Helpers;
using System;
using Microsoft.AspNetCore.Identity;

namespace HuertoDelValle.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        private SignInManager<IdentityUser> _signInManager;

        public CustomerController(ApplicationDbContext context, SignInManager<IdentityUser> sim)
        {
            _context = context;
            _signInManager = sim;
        }

        public IActionResult MisPedidos(){
            if(_signInManager.IsSignedIn(User)){

                var pedido = _context.DataPedido.OrderBy(x => x.idpedido).Include(x => x.estado).Include(z => z.tipoenvio).Where(x => x.cliente == User.Identity.Name).ToList();

                if(pedido == null)
                {
                    return NotFound();
                }
                
                return View(pedido);


            } else 
            {
                return NotFound();
            }
        }

        public IActionResult DetalleMiPedido(int? id){

            if(id == null){
                return NotFound();
            }            
            var detallePedido = _context.DataProductoPedido.Include(x => x.producto).Where(z => z.pedidoId == id ).ToList();
            
            if(detallePedido == null){
                return NotFound();
            }

            var pedido = _context.DataPedido.Find(id);

            if(pedido == null){
                return NotFound();
            }

            ViewBag.totalPedido = pedido.total;
            return View(detallePedido);
        }

        public IActionResult ConfirmarPedido(int? id){

            if(id == null){
                return NotFound();
            }

            var pedido = _context.DataPedido.Find(id);
            pedido.estadoid = 4;
            
            _context.Update(pedido);
            _context.SaveChanges();
      
            return RedirectToAction(nameof(MisPedidos));
        }


        
    }

}