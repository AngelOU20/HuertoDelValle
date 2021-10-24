using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using HuertoDelValle.Helpers;
using System.Security;


namespace HuertoDelValle.Controllers
{
    public class ProformaController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProformaController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: Proforma
        public IActionResult Proforma()
        {
            
            if(_signInManager.IsSignedIn(User)){
                 
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                var envios = SessionHelper.GetObjectFromJson<List<Envio>>(HttpContext.Session, "envio");
                ViewBag.envios = envios;

                    if(cart != null) { 
                        ViewBag.subtotal = cart.Sum(item => item.producto.PrecioProducto * item.cantidad); 
                        ViewBag.total = cart.Sum(item => item.producto.PrecioProducto * item.cantidad);

                        if(envios != null){
                            ViewBag.subtotal = cart.Sum(item => item.producto.PrecioProducto * item.cantidad); 
                            ViewBag.total = cart.Sum(item => item.producto.PrecioProducto * item.cantidad) + envios.Sum(item => item.tipoEnvio.precio);
                            

                        }
                    }

        
                ViewBag.tipoenvio = _context.DataTipoEnvio.ToList();

                

                return View();
            } else {
                return RedirectToAction("Login","Account");
            }
        }

        public IActionResult prueba(){
            return View();
        }
        
         public IActionResult Aprobada(){
            return View();
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { producto = _context.DataProducto.Find(id), cantidad = 1, Observaciones = ""});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                }
                else
                {
                    cart.Add(new Item { producto = _context.DataProducto.Find(id), cantidad = 1, Observaciones = ""});
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Catalogo", "Catalogo");
        }

        public IActionResult Buy1(int id, int cant)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { producto = _context.DataProducto.Find(id), cantidad = cant, Observaciones = ""});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                }
                else
                {
                    cart.Add(new Item { producto = _context.DataProducto.Find(id), cantidad = cant, Observaciones = ""});
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Catalogo", "Catalogo");
        }

        public IActionResult Quitar(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Proforma");
        }

        [HttpPost]
        public IActionResult Update(Microsoft.AspNetCore.Http.IFormCollection q) {
            
            string[] quantities = q["quantity"];
            List<Item> carrito = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            for(int i = 0; i< carrito.Count; i++) {
                carrito[i].cantidad = Convert.ToInt32(quantities[i]);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carrito);
            }
            return RedirectToAction("Proforma", "Proforma");

        }

        [HttpPost]
        public IActionResult envio(int id, string distrito) {
                List<Envio> tipoenvios = new List<Envio>();

                if(id != 0){
                tipoenvios.Add(new Envio{tipoEnvio=_context.DataTipoEnvio.Find(id), Direccion = distrito});
                } else {
                tipoenvios.Add(new Envio{tipoEnvio=_context.DataTipoEnvio.Find(1), Direccion = distrito});
                }
                
                SessionHelper.SetObjectAsJson(HttpContext.Session,"envio", tipoenvios);
                

                return RedirectToAction("Proforma");
        }

        public IActionResult recojoTienda(){
            List<Envio> tipoenvios = new List<Envio>();            
            tipoenvios.Add(new Envio{tipoEnvio=_context.DataTipoEnvio.Find(1), Direccion = ""});
            SessionHelper.SetObjectAsJson(HttpContext.Session,"envio", tipoenvios);

           return RedirectToAction("Proforma");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].producto.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        
    }

}