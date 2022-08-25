using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PartesPesca
{
    public class PartePesca
    {
        [Key]
        public int IDPP { get; set; }
        public int? IDMAR { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? ESTADO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CUADRICULA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? HORAINICIO { get; set; }
        public int? LANCESCANT { get; set; }
        public int? CAJONESCANT { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? CALIBRE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ESPECIE { get; set; }
        public double? KPROD { get; set; }
        public double? KCAPTURA { get; set; }
        public double? MASTERS { get; set; }

    }
}