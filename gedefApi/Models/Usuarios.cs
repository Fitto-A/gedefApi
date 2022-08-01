using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Usuarios
    {
        [Key]
        public int IDPERFIL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string USUARIO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CONTRASEÑA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CATEGORIA { get; set; }
    }
}
