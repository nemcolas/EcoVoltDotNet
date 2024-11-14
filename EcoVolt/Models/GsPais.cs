using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_pais")]
    public class GsPais
    {
        [Key]
        public int CodPais { get; set; }
        public string NomPais { get; set; }
        public ICollection<GsEstado> Estados { get; set; }
    }
}