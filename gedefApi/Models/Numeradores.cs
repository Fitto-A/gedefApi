using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class Numeradores
    {
        [Key]
        public int IDNUM { get; set; }

        public int MARCOUNT { get; set; }

        public int ROLXBARXMARCOUNT { get; set; }

    }
}
