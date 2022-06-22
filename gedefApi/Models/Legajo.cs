using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Legajo
    {
        [Key]
        public int LegajoId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public int Score { get; set; }
    }
}
