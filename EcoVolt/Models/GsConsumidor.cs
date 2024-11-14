using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_consumidor")]
    public class GsConsumidor
    {
        [Key]
        public int IdConsumidor { get; set; }
        public double EnergiaAtribuidaKwh { get; set; }
        public string NivelPrioridade { get; set; }
        public int IdTipoConsumidor { get; set; }
        [ForeignKey("IdTipoConsumidor")]
        public GsTipoConsumidor TipoConsumidor { get; set; }
        public int IdLocalizacao { get; set; }
        [ForeignKey("IdLocalizacao")]
        public GsLocalizacao Localizacao { get; set; }
        public ICollection<GsConsumoEnergia> ConsumosEnergia { get; set; }
    }
}