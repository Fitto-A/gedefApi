using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PartesPesca
{
    public class PFPFresqueros
    {
        [Key]
        public int IDPFP { get; set; }
        public int? IDMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHA { get; set; }
        public int? PSPTOT { get; set; }
        public int? DIASEFECTIVOS { get; set; }
        public int? CODBAR { get; set; }
        public int? TOTKILOS { get; set; }
        public int? TOTCAJONES { get; set; }
        
        [Column(TypeName = "nvarchar(256)")]
        public string? ESPECIES { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? ESPECIES2 { get; set; }
        public int? MRZ { get; set; }
        public int? MRZCAJ { get; set; }
        public int? RAYA { get; set; }
        public int? RAYACAJ { get; set; }
        public int? LANG { get; set; }
        public int? LANGCAJ { get; set; }
        public int? ABADEJO { get; set; }
        public int? ABADEJOCAJ { get; set; }
        public int? CALAMAR { get; set; }
        public int? CALAMARCAJ { get; set; }
        public int? OTROS { get; set; }
        public int? OTROSCAJ { get; set; }
    }

}
