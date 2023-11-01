using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Usuarios
    {
        //internal object errorMessage;

        [Key]
        public int IDPERFIL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USUARIO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CONTRASEÑA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CATEGORIA { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string? NOMBRE { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string? APELLIDO { get; set; }

        public int? DNI { get; set; }   

        [NotMapped]
        public string? ERRORMESSAGE { get; set; }

        [NotMapped]
        public float? EXPIRATIONTIME { get; set; }

        [NotMapped]
        public string? SID { get; set; }

    }
}
