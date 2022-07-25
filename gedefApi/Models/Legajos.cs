using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Legajos
    {
        [Key]
        public int Id { get; set; }
        public double? Legajo { get; set; }

        public double? Cuil { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Nombre { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Direccion { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Telefono { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Ciudad { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Provincia { get; set; }

        public double? CodPostal { get; set; }

        public double? Categoria { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Clase { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Mail { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Relevo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Empresa { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Certvin { get; set; }

        public double? Modalidad { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string? Egreso { get; set; }
    }
}


