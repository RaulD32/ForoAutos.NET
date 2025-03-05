using Bibloteca.Models.ViewModels;

namespace Bibloteca.Servicios.IServices
{
    public interface IAuthServices
    {
        Task<AuthResult> Login(string username, string password);
    }
}
