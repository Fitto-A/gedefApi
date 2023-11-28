using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models.RRHH
{
    [Keyless]
    public class FrancosTotal
    {
        public int? IDLEGAJO { get; set; }
        public double? FRANCOS { get; set;}
    }
}
