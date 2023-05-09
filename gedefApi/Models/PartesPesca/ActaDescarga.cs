
using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PartesPesca
{
    public class ActaDescarga
    {
        [Key]
        public int ID { get; set; }
        public int? NUMACTA { get; set; }
        public int? IDMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? TIPO { get; set; }

        public int? CODBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAINICIO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? HORAINICIO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAFIN { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? HORAFIN { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? ENCARGADO { get; set; }
        public int? DNI { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PUESTO { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? OBSERVACIONES { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? REVISIONBODEGA { get; set; }
    }
}
