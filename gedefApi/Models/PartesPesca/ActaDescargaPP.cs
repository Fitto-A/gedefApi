using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PartesPesca
{
    public class ActaDescargaPP
    {
        [Key]

        public int ID { get; set; }
        public int IDAD { get; set; }
        public int IDMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ESPECIE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PRODUCTOS { get; set; }
        public int? ENVASES { get; set; }
        public int? PROMEDIO { get; set; }
        public double? KGNETOS { get; set; }

    }
}
