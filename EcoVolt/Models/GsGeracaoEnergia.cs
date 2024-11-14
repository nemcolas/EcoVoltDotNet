using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_geracao_energia")]
    public class GsGeracaoEnergia
    {
        [Key]
        public int IdGeracao { get; set; }
        public DateTime Data { get; set; }
        public double GeracaoEnergiaKwh { get; set; }
        public int IdFonte { get; set; }
        [ForeignKey("IdFonte")]
        public GsFonteEnergia Fonte { get; set; }
    }
}