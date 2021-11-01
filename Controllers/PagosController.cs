using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HuertoDelValle.Models;
using HuertoDelValle.Data;
using Microsoft.AspNetCore.Identity;
using HuertoDelValle.Helpers;

namespace HuertoDelValle.Controllers
{
    public class PagosController : Controller
    {
        private readonly ILogger<PagosController> _logger;
        private readonly ApplicationDbContext _context;
        private SignInManager<IdentityUser> _signInManager;
        
        public PagosController(ILogger<PagosController> logger, ApplicationDbContext context, SignInManager<IdentityUser> sim)
        {
            _logger = logger;
            _context = context;
            _signInManager = sim;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         public IActionResult Checkout(){
            
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if(cart != null){
                List<Envio> envios = SessionHelper.GetObjectFromJson<List<Envio>>(HttpContext.Session, "envio");
                int countCar = cart.Count;
                var subtotal = cart.Sum(item => item.producto.PrecioProducto * item.cantidad);
                decimal total = 0;

                if(envios != null){
                    total = subtotal + envios.Sum(item => item.tipoEnvio.precio);
                } else {
                    total = subtotal;
                }

                int id=_context.DataPedido.Max(p => p.idpedido) + 1;

                Pedido p = new Pedido();
                p.idpedido = id;
                p.fechapedido = DateTime.Now;
                p.cantidad = cart.Count;
                p.total = total;
                p.cliente = User.Identity.Name;
                p.estadoid = 1;



                if(envios!= null){

                foreach (var hola in envios)
                {
                    p.direccion= hola.Direccion;
                    p.tipoenvioid = hola.tipoEnvio.Id;
                }
                } else {
                    p.tipoenvioid = 1;
                }
                
                _context.DataPedido.Add(p);
                _context.SaveChanges();

                foreach(Item item in cart){
                    
                    ProductoPedido cp = new ProductoPedido();
                    cp.pedidoId = p.idpedido;
                    cp.productoId = item.producto.Id;
                    cp.subtotal = item.producto.PrecioProducto * item.cantidad;
                    cp.cantidad = item.cantidad;
                    cp.observaciones = item.Observaciones;
                    _context.DataProductoPedido.Add(cp);
                    _context.SaveChanges();

                }
                TempData["prueba2"] = id;


                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                
                if(envios != null) {
                envios.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session,"envio",envios);
                }

               TempData["prueba"] = "prueba01";

            }
            return RedirectToAction("Catalogo", "Catalogo");
        }
    }
}
