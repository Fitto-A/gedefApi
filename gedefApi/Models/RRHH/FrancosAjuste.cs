using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace gedefApi.Models.RRHH
{
    public class FrancosAjuste 
    {
        [Key]
        public int ID { get; set; }
        public int IDLEGAJO { get; set; }
        public int LEGAJO { get; set; }
        public double AJUSTEFRANCO { get; set; }

    }
}
