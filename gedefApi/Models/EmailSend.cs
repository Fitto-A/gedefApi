using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class EmailSend
    {
        [Key]
        public int ID { get; set; }
        public int IDMAR { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? DESTINATION { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? DESTINATION2 { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? TITLE { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string? EMAILCONTENT { get; set; }

    }
}
