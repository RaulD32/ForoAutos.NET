using Bibloteca.Models.Domain;
namespace Bibloteca.Servicios.IServices
{
    public interface IMarcaServices
    {
        List<Marca> ObtenerMarcas();
        Task<bool> CrearMarca(Marca request);
        Task<Marca> ObtenerMarca(int id);
        Task<bool> ActualizarMarca(Marca request);
        Task<bool> EliminarMarca(int id);
    }
}
