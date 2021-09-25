using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HuertoDelValle.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private IEnumerable<Producto> _producto;
        private List<Categoria> ListaCategoria;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ILogger<CatalogoController> logger,
            ApplicationDbContext context ,  UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _producto = _context.DataProducto.ToList();
            ListaCategoria = _context.DataCategoria.ToList();

        }

        public IActionResult Producto(int Id){
            var producto = _context.DataProducto.Find(Id);
            return View(producto);
        }


        public async Task<IActionResult> Catalogo(int FiltrarCategoria,string Buscar)
        {
            dynamic modelo= new ExpandoObject();
            modelo.Categoria = ListaCategoria;

            var producto = from m in _producto
            select m;

            if(FiltrarCategoria!=0){
                _producto = _producto.Where(s => s.CategoriaId==FiltrarCategoria);
            }

            if(Buscar != null){
                _producto=_producto.Where(c => c.NombreProducto.ToUpper().Contains(Buscar.ToUpper())).OrderBy(s=>s.Id) .ToList();
            }

            modelo.Producto = _producto;
            return View(await Task.FromResult(modelo));
        }

        /*
        public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){ 
                ViewData["Message1"] = "Por favor debe loguearse antes de agregar un producto"; 
                return  RedirectToAction(nameof(Catalogo));
            }else{
                var producto = await _context.DataProducto.FindAsync(id);

                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Cantidad = 1;
                proforma.Precio = producto.PrecioProducto;
                proforma.SubTotal = proforma.Cantidad * producto.PrecioProducto;
                proforma.UserID = userID;
                
                _context.Add(proforma);
                
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Catalogo));
            }

            
        }
        */

        public async Task<IActionResult> Agregar(int? id, int cantidad)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){ 
                ViewData["Message1"] = "Por favor debe loguearse antes de agregar un producto"; /* Probar */
                return  RedirectToAction(nameof(Catalogo));
            }else{
                var producto = await _context.DataProducto.FindAsync(id);

                Proforma proforma = new Proforma();
                proforma.Producto = producto;

                if(cantidad == 0){
                    proforma.Cantidad = 1;
                }else{
                    proforma.Cantidad = cantidad;
                }
                
                proforma.Precio = producto.PrecioProducto;
                proforma.SubTotal = proforma.Cantidad * producto.PrecioProducto;
                proforma.UserID = userID;
                
                _context.Add(proforma);
                
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Catalogo));
            }

            
        }

    }
}