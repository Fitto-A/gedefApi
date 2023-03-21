using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PartesPesca
{
    public class Motivos
    {
        [Key]
        public int IDPP { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ESTADO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USOS { get; set; }

    }
}