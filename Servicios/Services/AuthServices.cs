using Bibloteca.Context;
using Bibloteca.Models.Domain;
using Bibloteca.Models.ViewModels;
using Bibloteca.Servicios.IServices;
using Microsoft.EntityFrameworkCore;

namespace Bibloteca.Servicios.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly ApplicationDBContext _context;

        public AuthServices(ApplicationDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<AuthResult> Login(string username, string password)
        {
            try
            {
                // Buscar el usuario
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);

                if (usuario == null)
                {
                    return new AuthResult { Success = false };
                }
                if (usuario.FkRol == 1)
                {
                    return new AuthResult { Success = true, Rol = "Admin" };
                }

                return new AuthResult { Success = false };
            }
            catch (Exception e)
            {
                return new AuthResult { Success = false };
            }
        }
    }
}
