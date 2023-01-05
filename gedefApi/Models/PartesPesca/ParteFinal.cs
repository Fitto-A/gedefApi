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

        public double? KPROD { get; set; }
        public double? KCAPTURA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }
        public int? PSPTOT { get; set; }
        public double? L1 { get; set; }
        public double? L2 { get; set; }
        public double? L3 { get; set; }
        public double? L4 { get; set; }
        public double? C1 { get; set; }
        public double? C1KCAPTURA { get; set; }
        public double? C2 { get; set; }
        public double? C2KCAPTURA { get; set; }
        public double? CR { get; set; }
        public double? CRKCAPTURA { get; set; }
        public int? CODBAR { get; set; }
        public int? DIASEFECTIVOS { get; set; }
        
        [Column(TypeName = "nvarchar(256)")]
        public string? ESPECIES { get; set; }
        public double? MRZ { get; set; }

    }
}
