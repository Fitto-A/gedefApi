using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Numeradores
    {
        [Key]
        public int IDNUM { get; set; }

        public int COUNTER { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? NOMBRE { get; set; }

    }
}
