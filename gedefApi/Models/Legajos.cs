using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Legajos
    {
        [Key]
        public int Legajo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Cuil { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Direccion { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Telefono { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Ciudad { get; set; }

        [Column(TypeName = "nchar(20)")]
        public string Provincia { get; set; }

        public int CodPos { get; set; }

        [Column(TypeName = "nchar(20)")]
        public string Categoria { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string Clase { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Mail { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string Relevo { get; set; }
    }
}
