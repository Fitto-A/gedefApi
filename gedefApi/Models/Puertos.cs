using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Puertos
    {
        [Key]
        public int CODPUE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NOMPUE { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ACTPUE { get; set; }

    }
}
