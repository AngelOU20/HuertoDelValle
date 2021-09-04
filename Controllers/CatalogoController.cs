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

        public async Task<IActionResult> Catalogo(int FiltrarCategoria)
        {
            dynamic modelo= new ExpandoObject();
            modelo.Categoria = ListaCategoria;

            var producto = from m in _producto
            select m;

            if(FiltrarCategoria!=0){
            _producto = _producto.Where(s => s.CategoriaId==FiltrarCategoria);
            }
            modelo.Producto = _producto;
            return View(await Task.FromResult(modelo));
        }

    }
}