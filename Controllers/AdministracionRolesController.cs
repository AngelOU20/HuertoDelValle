using System.Threading.Tasks;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HuertoDelValle.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdministracionRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministracionRolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult RolCreado()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RolCrear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CrearRol model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("RolCreado", "AdministracionRoles");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}