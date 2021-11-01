using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HuertoDelValle.Models;
using HuertoDelValle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HuertoDelValle.Controllers
{
    public class PedidosController : Controller
    {
        private UserManager<IdentityUser> _userManager;
         private SignInManager<IdentityUser> _signInManager;
          private ApplicationDbContext _context;
          
        private readonly ILogger<PedidosController> _logger;
        public PedidosController(ILogger<PedidosController> logger, ApplicationDbContext c, UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            _userManager =um;
            _signInManager = sim;
            _logger = logger;
            _context = c;
        }

        public IActionResult Pedidos()
        {
            var pedido=_context.DataPedido.OrderBy(x => x.idpedido).Include(x => x.estado).Include(z => z.tipoenvio).ToList();
            
            return View(pedido);
        }

        public IActionResult PedidoProceso(int? id){

            if(id == null){
                return NotFound();
            }

            var pedido = _context.DataPedido.Find(id);
            pedido.estadoid = 2;
            
            _context.Update(pedido);
            _context.SaveChanges();
      
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult DetallePedido(int? id){

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
    }
}