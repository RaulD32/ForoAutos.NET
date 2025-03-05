using Bibloteca.Models.Domain;
using Bibloteca.Servicios.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Bibloteca.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaServices _marcaServices;

        public MarcaController(IMarcaServices marcaServices)
        {
            _marcaServices = marcaServices;
        }

        public IActionResult Index()
        {
            var marcas = _marcaServices.ObtenerMarcas();
            return View(marcas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Marca request)
        {
            await _marcaServices.CrearMarca(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var marca = await _marcaServices.ObtenerMarca(id);
            if (marca == null) return NotFound();
            return View(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Marca request)
        {
            bool actualizado = await _marcaServices.ActualizarMarca(request);
            if (!actualizado)
            {
                ModelState.AddModelError("", "No se pudo actualizar la marca");
                return View(request);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _marcaServices.EliminarMarca(id);
            return Json(new { success = eliminado, message = eliminado ? "Marca eliminada correctamente." : "No se pudo eliminar la marca." });
        }

        
    }
}
