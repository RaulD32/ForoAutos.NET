using Bibloteca.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bibloteca.Servicios.IServices
{
    public interface ICocheServices
    {
        Task<List<Coche>> ObtenerCoches();
        Task<Coche> ObtenerCochePorId(int id);
        Task<bool> CrearCoche(Coche coche);
        Task<bool> ActualizarCoche(Coche coche);
        Task<bool> EliminarCoche(int id);
    }
}
