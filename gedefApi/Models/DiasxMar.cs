using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gedefApi.Models
{
    public class DiasxMar
    {
        [Key]
        public int ID { get; set; }
        public int IDMAREA { get; set; }
        public int? IDLEGAJO { get; set; }
        public int? DIASGUARDIA { get; set; }
        public int? DIASTRABAJO { get; set; }
        public int? TOTAL { get; set; }
    }
}
