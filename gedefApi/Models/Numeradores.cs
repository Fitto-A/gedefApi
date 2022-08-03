using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Numeradores
    {
        [Key]
        public int IDNUM { get; set; }

        public int MARCOUNT { get; set; }

        [Column(TypeName = "nchar(10)")]
        public int NOMBRE { get; set; }

    }
}
