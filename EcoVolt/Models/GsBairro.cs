using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_bairro")]
    public class GsBairro
    {
        [Key]
        public int CodBairro { get; set; }
        public string Nome { get; set; }
        public int CodCidade { get; set; }
        [ForeignKey("CodCidade")]
        public GsCidade Cidade { get; set; }
        public ICollection<GsLocalizacao> Localizacoes { get; set; }
    }
}