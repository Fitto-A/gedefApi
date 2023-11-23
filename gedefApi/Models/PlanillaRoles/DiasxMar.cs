﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models.PlanillaRoles
{
    public class DiasxMar
    {
        [Key]
        public int ID { get; set; }
        public int IDMAREA { get; set; }
        public int? IDLEGAJO { get; set; }
        public int? DIASGUARDIA { get; set; }
        public int? DIASTRABAJO { get; set; }
        public int? DIASTRABAJOESPECIAL { get; set; }
        public int? TOTAL { get; set; }
        public double? VIATICOS { get; set; }
        public double? FRANCOS { get; set; }

        [Column (TypeName = "nvarchar(50)")]
        public string? PERIODO { get; set; }
    }
}
