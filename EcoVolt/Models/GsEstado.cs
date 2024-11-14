using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_estado")]
    public class GsEstado
    {
        [Key]
        public int CodEstado { get; set; }
        public string NomEstado { get; set; }
        public int CodPais { get; set; }
        [ForeignKey("CodPais")]
        public GsPais Pais { get; set; }
        public ICollection<GsCidade> Cidades { get; set; }
    }
}