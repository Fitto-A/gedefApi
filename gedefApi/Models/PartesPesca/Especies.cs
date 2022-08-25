using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PartesPesca
{
    public class Especies
    {
        [Key]
        public int IDESP { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string? ESPECIE { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string? CALIBRE { get; set; }
        public double? CONVERSION { get; set; }

    }
}
