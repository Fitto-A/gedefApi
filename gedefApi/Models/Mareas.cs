using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models
{
    public class Mareas
    {
        [Key]
        public int CODMAR { get; set; }
        public int CODROLXBARXMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHASAL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAENT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PUERTOSAL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PUERTOENT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? VIAJE { get; set; }
        public int CODBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ARMADOR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NOMBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHACREACION { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ESTADO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAACTIVACION { get; set; }

    }
}
