using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PlanillaRoles
{
    public class Roles
    {
        [Key]
        public int IDROL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ROL { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ACTIVO { get; set; }
        public int? CODROL { get; set; }
        public int? VERAZ { get; set; }
        public int? PESPASA { get; set; }

    }
}
