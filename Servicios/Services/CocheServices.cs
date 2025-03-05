using Bibloteca.Context;
using Bibloteca.Models.Domain;
using Bibloteca.Servicios.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bibloteca.Servicios.Services
{
    public class CocheServices : ICocheServices
    {
        private readonly ApplicationDBContext _context;

        public CocheServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Coche>> ObtenerCoches()
        {
            return await _context.Coches.Include(c => c.Marca).ToListAsync();
        }

        public async Task<Coche> ObtenerCochePorId(int id)
        {
            return await _context.Coches.Include(c => c.Marca).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CrearCoche(Coche coche)
        {
            _context.Coches.Add(coche);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarCoche(Coche coche)
        {
            var cocheExistente = await _context.Coches.FindAsync(coche.Id);
            if (cocheExistente == null) return false;

            cocheExistente.Modelo = coche.Modelo;
            cocheExistente.Anio = coche.Anio;
            cocheExistente.MarcaId = coche.MarcaId;

            _context.Coches.Update(cocheExistente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarCoche(int id)
        {
            var coche = await _context.Coches.FindAsync(id);
            if (coche == null) return false;

            _context.Coches.Remove(coche);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
