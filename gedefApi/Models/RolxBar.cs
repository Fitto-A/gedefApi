using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gedefApi.Models
{
    public class RolxBar
    {
        [Key]
        public int CODROLXBAR { get; set; }

        public int CODBAR { get; set; }
        [Column(TypeName = "nchar(1)")]
        public string CAPITAN { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string PRIMEROF { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string JEFEMAQUINA { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string PRIMEROFMAQ { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string SEGUNOFMAQ { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string CONTRAMCUB { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string CONTRAMPLA { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string COCINERO { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string ENGRASADOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string ENFERMERO { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINCUBGUIN { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINCUB1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINCUB2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINCUB3 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINCUB4 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINCUB5 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string BODEG1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string BODEG2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string TUNELERO { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINERO { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string LAVADOR { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA1 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA2 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA3 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA4 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA5 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA6 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA7 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA8 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA9 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA10 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA11 { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string MARINPLA12 { get; set; }

    }
}
