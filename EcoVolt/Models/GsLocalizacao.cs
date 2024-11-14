using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_localizacao")]
    public class GsLocalizacao
    {
        [Key]
        public int IdLocalizacao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string EnderecoCompleto { get; set; }
        public int CodBairro { get; set; }
        [ForeignKey("CodBairro")]
        public GsBairro Bairro { get; set; }
        public ICollection<GsConsumidor> Consumidores { get; set; }
    }
}