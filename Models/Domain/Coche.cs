using System.ComponentModel.DataAnnotations.Schema;

namespace Bibloteca.Models.Domain
{
    [Table("Coches")]
    public class Coche
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }

        // Relaciones
        [ForeignKey(nameof(Marca))]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
