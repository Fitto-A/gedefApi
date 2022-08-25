using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PartesPesca
{
    public class ParteFinal
    {
        [Key]
        public int IDPFP { get; set; }
        public int? IDMAR { get; set; }
        public double? TOTENT { get; set; }
        public double? TOTCOLA { get; set; }
        public double? ENTYCOLA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ESPECIES { get; set; }
        public double? KPROD { get; set; }
        public double? KCAPTURA { get; set; }
    }
}
