using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PartesPesca
{
    public class PFPCongeladores
    {
        [Key]
        public int IDPFP { get; set; }
        public int? IDMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }
        public int? PSPTOT { get; set; }
        public int? DIASEFECTIVOS { get; set; }
        public int? CODBAR { get; set; }
        public double? TOTENT { get; set; }
        public double? TOTCOLA { get; set; }
        public double? ENTYCOLA { get; set; }
        public double? KPROD { get; set; }
        public double? KCAPTURA { get; set; }
        public int? L1 { get; set; }
        public int? L2 { get; set; }
        public int? L3 { get; set; }
        public int? L4 { get; set; }
        public int? C1 { get; set; }
        public int? C1KCAPTURA { get; set; }
        public int? C2 { get; set; }
        public int? C2KCAPTURA { get; set; }
        public int? CR { get; set; }
        public int? CRKCAPTURA { get; set; }
        public int? MRZ { get; set; }
        public int? OTROS { get; set; }
    }
}
