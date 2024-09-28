using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC2.Models;
using PC2.Data;

namespace PC2.Controllers
{
    [Route("[controller]")]
    public class Cuentasbancarias : Controller
    {
        private readonly ILogger<Cuentasbancarias> _logger;
        private readonly ApplicationDbContext _context; // Agregamos el contexto de la base de datos

        public Cuentasbancarias(ILogger<Cuentasbancarias> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Inyectamos el contexto
        }

        // Acción para mostrar el listado de bancos
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var bancos = await _context.DataBanco.ToListAsync();
            return View(bancos); // Pasamos la lista de bancos a la vista
        }

        // Acción para mostrar el formulario de registro
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}