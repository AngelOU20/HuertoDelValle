using System.Linq;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HuertoDelValle.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context){
            _context = context;
        }
        
        public IActionResult AdministrarProducto(){
            var producto = _context.DataProducto.Include(x => x.Categoria).OrderBy(r => r.Id).ToList();
            return View(producto);
        }

        public IActionResult AgregarProducto(){
            ViewBag.categoria=_context.DataCategoria.ToList().Select(r => new SelectListItem(r.NombreCategoria, r.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(Producto p){
            if(ModelState.IsValid){
                _context.Add (p);
                _context.SaveChanges();
                return RedirectToAction("AdministrarProducto");
            }
            return View(p);
        }

        public IActionResult EditarProducto(int Id) {
            var producto = _context.DataProducto.Find(Id);
            ViewBag.categoria=_context.DataCategoria.ToList().Select(r => new SelectListItem(r.NombreCategoria, r.Id.ToString()));
            return View(producto);
        }

        [HttpPost]
        public IActionResult EditarProducto(Producto p) {
            if (ModelState.IsValid) {
                var producto = _context.DataProducto.Find(p.Id);  
                producto.NombreProducto = p.NombreProducto;
                producto.ImagenProducto = p.ImagenProducto;
                producto.DescripcionProducto = p.DescripcionProducto;
                producto.PrecioProducto = p.PrecioProducto;
                producto.Stock = p.Stock;
                producto.CategoriaId=p.CategoriaId;
                _context.SaveChanges();
                return RedirectToAction("AdministrarProducto");
            }
            return View(p);
        }

         public IActionResult DetalleProducto(int Id){
            var producto = _context.DataProducto.Find(Id);
            return View(producto);
        }

        public IActionResult EliminarProducto(int Id) 
        {
            var Producto= _context.DataProducto.Find(Id);
            _context.Remove(Producto);
            _context.SaveChanges();
            return RedirectToAction("AdministrarProducto");
        }


        
    }
}