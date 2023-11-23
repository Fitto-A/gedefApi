﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models
{
    public class Mareas
    {
        [Key]
        public int IDMAR { get; set; }
        public int CODROLXBARXMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHASAL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAENT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PUERTOSAL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PUERTOENT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? TRIPULANTEEXTRA { get; set; }
        public int? MILLASCANT { get; set; }
        public int? COMBUSTIBLE { get; set; }
        public int CODBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ARMADOR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NOMBAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHACREACION { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ESTADO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAACTIVACION { get; set; }

        [Column(TypeName = "nchar(4)")]
        public string? ANO { get; set; }
        public int? NUMMAREA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FECHAFINALIZACION { get; set; }
        public int? TRIPULANTESCANT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? HORASALIDA { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? HORAENTRADA { get; set; }

        [Column(TypeName = "nchar(1)")]
        public string? ACTADESCARGA { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string? VARIANTE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CAMBIOESTADO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? USERCAMBIOESTADO { get; set; }

    }
}
