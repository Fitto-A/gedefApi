using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class TBA_BARCOS
    {
        [Key]
        public int IDBAR { get; set; }

        [Column(TypeName = "nvachar(3)")]
        public string CODBAR { get; set; }

        [Column(TypeName = "nvachar(50)")]
        public string NOMBAR { get; set; }

        public int NUMMAR { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string ACTBAR { get; set; }
    }
}
