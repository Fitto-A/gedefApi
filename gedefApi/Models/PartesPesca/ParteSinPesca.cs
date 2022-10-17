using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PartesPesca
{
    public class ParteSinPesca
    {
        [Key]
        public int IDPSP { get; set; }
        public int? IDMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? MOTIVO { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? OBSERVACIONES { get; set; }
        public int? CODBAR { get; set; }

    }
}
