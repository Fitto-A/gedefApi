using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PlanillaRoles
{
    public class DiasExtraordinarios
    {
        [Key]
        public int ID { get; set; }

        public int IDMAR { get; set; }

        public int? DIAS { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? MOTIVO { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? OBSERVACIONES { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USERCREADOR { get; set; }
        public int? LEGAJO { get; set; }
    }
}
