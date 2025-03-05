using Bibloteca.Models.Domain;
using System.Collections.Generic;

namespace Bibloteca.Servicios.IServices
{
    public interface INoticiaServices
    {
        List<Noticia> ObtenerNoticias();
        Noticia ObtenerNoticia(int id);
        bool CrearNoticia(Noticia noticia);
        bool ActualizarNoticia(Noticia noticia);
        bool EliminarNoticia(int id);
    }
}
