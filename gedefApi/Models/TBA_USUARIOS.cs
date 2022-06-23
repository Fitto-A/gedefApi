using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class TBA_USUARIOS
    {
        [Key]
        public int USUARIOID { get; set; }

        [Column(TypeName = "nvachar(50)")]
        public string USUARIO { get; set; }

        [Column(TypeName = "nvachar(50)")]
        public string CONTRASEÑA { get; set; }

        [Column(TypeName = "nvachar(50)")]
        public string CATEGORIA { get; set; }
    }
}
