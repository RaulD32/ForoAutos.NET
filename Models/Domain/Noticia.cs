using System.ComponentModel.DataAnnotations.Schema;

namespace Bibloteca.Models.Domain
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }

        // Relaciones
        [ForeignKey(nameof(Coche))]
        public int CocheId { get; set; }
        public Coche Coche { get; set; }
    }
}
