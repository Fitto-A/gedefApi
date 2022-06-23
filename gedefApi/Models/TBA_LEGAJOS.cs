using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class TBA_LEGAJOS
    {
        [Key]
        public int IDLEG { get; set; }
        public int LEGAJO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CUIL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NOMBRE { get; set; }

        public int CODPOS { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string RELEVO { get; set; }
    }
}
