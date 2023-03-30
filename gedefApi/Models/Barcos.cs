using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Barcos
    {
        [Key]
        public int CODBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NOMBAR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public int? ACTBAR { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string? NOMABREV { get; set; }
        public int? ARMADOR1 { get; set; }
        public int? ARMADOR2 { get; set; }
        public int? TRIPULACION { get; set; }
        public int? TRIPULACIONMAX { get; set; }
        public int? CAPACIDAD { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string? EMPRESA { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string? UNIDAD { get; set; }
        public int? ARMADOR3 { get; set; }
        public int? ARMADOR4 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USUARIOBARCO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USUARIOBARCO2 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? TIPO { get; set; }
        public int? TRIPULACIONMIN { get; set; }
        public int? CAPITAN1 { get; set; }
        public int? CAPITAN2 { get; set; }
        public int? CAPITAN3 { get; set; }
        public int? CAPITAN4 { get; set; }
    }
}
