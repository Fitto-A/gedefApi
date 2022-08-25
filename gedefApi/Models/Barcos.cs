using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Barcos
    {
        [Key]
        public int CODBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NOMBAR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public int? ACTBAR { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string? NOMABREV { get; set; }
        public int? ARMADOR1 { get; set; }
        public int? ARMADOR2 { get; set; }

    }
}
