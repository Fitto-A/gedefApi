using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Sueldos
    {
        [Key]
        public int IDROL { get; set; }
        public decimal? BASICO { get; set; }
        public decimal? PCTJE_ADIC_GARANTIZADO { get; set; }

        [NotMapped]
        public decimal? GARANTIZADO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? LASTUPDATE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USER { get; set; }

        [Column(TypeName = "char(3)")]
        public string? IDEMP { get; set; }

        public decimal? PARTES_CON_GASTOS { get; set; }

        public decimal? PARTES_SIN_GASTOS { get; set; }
    
    }

}
