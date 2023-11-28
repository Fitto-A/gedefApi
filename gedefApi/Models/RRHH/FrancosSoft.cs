using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.RRHH
{
    [Keyless]
    public class FrancosSoft
    {
        [Column(TypeName = "nvarchar(255)")]
        public string? IDLEGAJO { get; set; }
        public double? FRANCOS { get; set; }
    }
}
