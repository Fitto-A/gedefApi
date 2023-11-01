using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Legajos
    {
        [Key]
        public int Id { get; set; }
        public int? Legajo { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string? Cuil { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Nombre { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Direccion { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Telefono { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Ciudad { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Provincia { get; set; }

        public int? CodPostal { get; set; }

        [Column(TypeName = "nchar(20)")]
        public string? Categoria { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string? Clase { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Mail { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? Relevo { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? Empresa { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string Certvin { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string? Modalidad { get; set; }

        //[Column(TypeName = "nchar(10)")]
        //public string? Egreso { get; set; }


        [Column(TypeName = "varchar(9)")]
        public string Sexo { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string? Ecivil { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Nacionalidad { get; set; }

        public DateTime Fnacimiento { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Beneficiario { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string? Dnibeneficiario { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string? Nrolibreta { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? Sindicato { get; set; }

        public int Roles { get; set; }
        public DateTime? Vencimiento { get; set; }

    }

}


