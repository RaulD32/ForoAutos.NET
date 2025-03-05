using Bibloteca.Context;
using Bibloteca.Models.Domain;
using Bibloteca.Servicios.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bibloteca.Servicios.Services
{
    public class NoticiaServices : INoticiaServices
    {
        private readonly ApplicationDBContext _context;

        public NoticiaServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Noticia> ObtenerNoticias()
        {
            return _context.Noticias.Include(x => x.Coche)
                .ToList();
        }

        public Noticia ObtenerNoticia(int id)
        {
            return _context.Noticias.FirstOrDefault(n => n.Id == id);
        }

        public bool CrearNoticia(Noticia noticia)
        {
            _context.Noticias.Add(noticia);
            return _context.SaveChanges() > 0;
        }

        public bool ActualizarNoticia(Noticia noticia)
        {
            _context.Noticias.Update(noticia);
            return _context.SaveChanges() > 0;
        }

        public bool EliminarNoticia(int id)
        {
            var noticia = _context.Noticias.Find(id);
            if (noticia == null) return false;

            _context.Noticias.Remove(noticia);
            return _context.SaveChanges() > 0;
        }
    }
}
