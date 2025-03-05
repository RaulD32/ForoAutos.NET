using Bibloteca.Models.ViewModels;
using Bibloteca.Servicios.IServices;
using Bibloteca.Servicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpGet("Login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authServices.Login(model.UserName, model.Password);

            if (!result.Success)
            {
                ViewData["Error"] = "Usuario o contraseña incorrectos.";
                return View("Index", model);
            }

            if (result.Rol == "Admin")
            {
                return RedirectToAction("Index", "Usuario");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
