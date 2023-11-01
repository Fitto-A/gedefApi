using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models
{
    public class Puertos
    {
        [Key]
        public int IDPUE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NOMPUE { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ACTPUE { get; set; }

        [Column(TypeName = "nchar(4)")]
        public string? NOMABREV { get; set; }

        //[Column(TypeName = "SqlInt32")]

        //public SqlGeometry? COORDERNADAS { get; set; }

    }
}
