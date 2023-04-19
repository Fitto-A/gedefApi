using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models.PlanillaRoles
{

    public class RolxBar
    {
        [Key]
        public int CODROLXBAR { get; set; }

        public int CODBAR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? CAPITAN { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? PATRON { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? SEGUNPATRON { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? PRIMOFCUBIERTA { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? JEFEMAQUINAS { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? SEGUNJEFEMAQUINAS { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? PRIMOFMAQUINAS { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? SEGUNOFMAQUINAS { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? PRIMOFCONDUCTOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? SEGUNOFCONDUCTOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? PRIMPESCADOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? SEGUNPESCADOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? CONTRAMCUBIERTA { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? CONTRAMPLANTA { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? COCINERO { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? COCINERO2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ENGRASADOR1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ENGRASADOR2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? BODEGUERO1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? BODEGUERO2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? TUNELERO1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? TUNELERO2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? GUINCHERO1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? GUINCHERO2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? LAVADOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ENFERMERO { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO2 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO3 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO4 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO5 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO6 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO7 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO8 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO9 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO10 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO11 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO12 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO13 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO14 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO15 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO16 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO17 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO18 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO19 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO20 { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string? MARINERO21 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO22 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO23 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO24 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO25 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO26 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO27 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINERO28 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA3 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA4 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA5 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA6 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA7 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA8 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA9 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROPLA10 { get; set; }


        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB3 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB4 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB5 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB6 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB7 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB8 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB9 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? MARINEROCUB10 { get; set; }


    }
}
