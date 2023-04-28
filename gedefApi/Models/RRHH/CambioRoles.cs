using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.RRHH
{
    public class CambioRoles
    {
        [Key]
        public int ID { get; set; }
        public int IDMAR { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? FECHA { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? ROL { get; set; }
        public int? BAJA { get; set; }
        public int? SUBE { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? MOTIVO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USUARIO { get; set; }

    }
}
