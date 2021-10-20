using System;
using System.Linq;
using HuertoDelValle.Data;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace HuertoDelValle.Controllers
{
    public class CrearPDFController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CrearPDFController(ApplicationDbContext context){
            _context = context;
        }
        
        public IActionResult Index(){
            var producto = _context.DataProducto.Include(x => x.Categoria).OrderBy(r => r.Id).ToList();
            return new ViewAsPdf("Index" , producto )
            {
                /*PageSize = Rotativa.AspNetCore.Options.Size.A4, Tamaño*/
                /*PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape, Orientación del pdf*/
                FileName = "Lista de Productos.pdf"
            };
        }
    }
}