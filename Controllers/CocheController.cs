using Bibloteca.Models.Domain;
using Bibloteca.Servicios.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bibloteca.Controllers
{
    public class CocheController : Controller
    {
        private readonly ICocheServices _cocheServices;
        private readonly IMarcaServices _marcaServices;

        public CocheController(ICocheServices cocheServices, IMarcaServices marcaServices)
        {
            _cocheServices = cocheServices;
            _marcaServices = marcaServices;
        }

        public async Task<IActionResult> Index()
        {
            var coches = await _cocheServices.ObtenerCoches();
            return View(coches);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Marcas = _marcaServices.ObtenerMarcas()
                .Select(m => new SelectListItem
                {
                    Text = m.Nombre,
                    Value = m.Id.ToString()
                }).ToList();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Coche request)
        {
            await _cocheServices.CrearCoche(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var coche = await _cocheServices.ObtenerCochePorId(id);
            if (coche == null) return NotFound();

            ViewBag.Marcas = _marcaServices.ObtenerMarcas()
                .Select(m => new SelectListItem
                {
                    Text = m.Nombre,
                    Value = m.Id.ToString(),
                    Selected = m.Id == coche.MarcaId
                }).ToList();

            return View(coche);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Coche request)
        {
            bool actualizado = await _cocheServices.ActualizarCoche(request);
            if (!actualizado)
            {
                ModelState.AddModelError("", "No se pudo actualizar el coche");
                return View(request);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _cocheServices.EliminarCoche(id);
            return Json(new { success = eliminado, message = eliminado ? "Coche eliminado correctamente." : "No se pudo eliminar el coche." });
        }
    }
}
