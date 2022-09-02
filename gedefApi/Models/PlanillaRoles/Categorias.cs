using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PlanillaRoles
{
    public class Categorias
    {
        public double CODIGO { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? DESCRIP { get; set; }
    }
}
