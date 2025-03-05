using Bibloteca.Context;
using Bibloteca.Models.Domain;
using Bibloteca.Servicios.IServices;
using Microsoft.EntityFrameworkCore;

namespace Bibloteca.Servicios.Services
{
    public class MarcaServices : IMarcaServices
    {
        private readonly ApplicationDBContext _context;

        public MarcaServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Marca> ObtenerMarcas()
        {
            return _context.Marcas.ToList();
        }

        public async Task<bool> CrearMarca(Marca request)
        {
            try
            {
                _context.Marcas.Add(request);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la marca: " + ex.Message);
            }
        }

        public async Task<Marca> ObtenerMarca(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<bool> ActualizarMarca(Marca request)
        {
            try
            {
                _context.Marcas.Update(request);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la marca: " + ex.Message);
            }
        }

        public async Task<bool> EliminarMarca(int id)
        {
            try
            {
                var marca = await _context.Marcas.FindAsync(id);
                if (marca == null) return false;

                _context.Marcas.Remove(marca);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la marca: " + ex.Message);
            }
        }
    }
}
