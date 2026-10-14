using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneosEsports.Web.Data;

namespace TorneosEsports.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            int totalUsuarios = _userManager.Users.Count();

            ViewBag.TotalUsuarios = totalUsuarios;

            return View();
        }

        public async Task<IActionResult> Bitacora()
        {
            var registros = await _context.BitacoraAcciones
                .OrderByDescending(b => b.FechaHora)
                .Take(100)
                .ToListAsync();

            return View(registros);
        }
    }
}