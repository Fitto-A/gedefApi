using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Plantillas
    {
        [Key]
        public int CODPLA { get; set; }
        public int CODROLXBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NOMBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ARMADOR { get; set; }

        public int CODMAR { get; set; }
    }
}
