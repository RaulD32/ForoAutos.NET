using Bibloteca.Models.Domain;
using Bibloteca.Servicios.IServices;
using Bibloteca.Servicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;



namespace Bibloteca.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaServices _noticiaServices;
        private readonly ICocheServices _cocheServices;

        public NoticiaController(INoticiaServices noticiaServices, ICocheServices cocheServices)
        {
            _noticiaServices = noticiaServices;
            _cocheServices = cocheServices;
        }

        // Listar noticias
        public IActionResult Index()
        {
            var noticias = _noticiaServices.ObtenerNoticias();
            return View(noticias);
        }

        // Crear noticia (GET)
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            List<Coche> coches = await _cocheServices.ObtenerCoches();
            ViewBag.Coches = coches.Select(c => new SelectListItem
            {
                Text = c.Modelo,
                Value = c.Id.ToString()
            });
            return View();
        }

        // Crear noticia (POST)
        [HttpPost]
        public IActionResult Crear(Noticia noticia)
        {
            bool creado = _noticiaServices.CrearNoticia(noticia);
            if (creado)
                return RedirectToAction("Index");

            return View();
        }

        // Editar noticia (GET)
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var noticia = _noticiaServices.ObtenerNoticia(id);
            if (noticia == null) return NotFound();

            List<Coche> coches = await _cocheServices.ObtenerCoches();
            ViewBag.Coches = coches.Select(c => new SelectListItem
            {
                Text = c.Modelo,
                Value = c.Id.ToString(),
                Selected = c.Id == noticia.CocheId
            });

            return View(noticia);
        }

        // Editar noticia (POST)
        [HttpPost]
        public IActionResult Editar(Noticia noticia)
        {
        
            bool actualizado = _noticiaServices.ActualizarNoticia(noticia);
            if (actualizado)
                return RedirectToAction("Index");

            return View();
        }

        // Eliminar noticia (POST)
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = _noticiaServices.EliminarNoticia(id);
            return Json(new { success = eliminado, message = eliminado ? "Noticia eliminada correctamente." : "No se pudo eliminar la noticia." });
        }
    }
}