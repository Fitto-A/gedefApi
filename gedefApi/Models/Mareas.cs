﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models
{
    public class Mareas
    {
        [Key]
        public int CODMAR { get; set; }
        public int CODROLXMAR { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FECHASAL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FECHAENT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PUERTOSAL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PUERTOENT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VIAJE { get; set; }
        public int CODBAR { get; set; }
    }
}