using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class TBA_PLANTILLAS
    {
        [Key]
        public int IDPLA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CODPLA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NOMBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NUMMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CODROLXBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CAPITAN { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PRIMEROF { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string COCINERO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MARINCUB1 { get; set; }
    }
}
