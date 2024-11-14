using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_cidade")]
    public class GsCidade
    {
        [Key]
        public int CodCidade { get; set; }
        public string NomCidade { get; set; }
        public int CodEstado { get; set; }
        [ForeignKey("CodEstado")]
        public GsEstado Estado { get; set; }
        public ICollection<GsBairro> Bairros { get; set; }
    }
}