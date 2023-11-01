using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Empresas
    {
        [Key]

        [Column(TypeName = "char(3)")]
        public string ID { get; set; }

        [Column(TypeName = "char(3)")]
        public string CUIT { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string RAZONSOCIAL { get; set; }
        
        [Column(TypeName = "varchar(75)")]
        public string DOMICILIO { get; set; }

        public int CODPOS { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string CIUDAD { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string PROVINCIA { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string RESPONSABLE { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string ROLRESP { get; set; }
    }
}
