using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class TBA_ROLXBAR
    {
        [Column(TypeName = "nvachar(3)")]
        public string CODROLXBAR { get; set; }

        [Column(TypeName = "nvachar(3)")]
        public string CODBAR { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string CAPITAN { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string PRIMEROF { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string JEFEMAQUINA { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string COCINERO { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string MARINCUB1 { get; set; }

        [Column(TypeName = "nvachar(1)")]
        public string MARINPLA1 { get; set; }
    }
}
