using System.ComponentModel.DataAnnotations.Schema;

namespace Bibloteca.Models.Domain
{
    [Table("Marcas")]
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
