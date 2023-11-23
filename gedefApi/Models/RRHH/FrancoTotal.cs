using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models.RRHH
{
    [Keyless]
    public class FrancoTotal
    {
        public int? IDLEGAJO { get; set; }
        public double? FRANCOS { get; set;}
    }
}
