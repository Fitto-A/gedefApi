using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Question
    {
        [Key]
        public int QnId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string QnInWords { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ImageName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Opion1 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Opion2 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Opion3 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Opion4 { get; set; }
        public int Answer { get; set; }

    }
}
