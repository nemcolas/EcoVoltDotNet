using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_consumo_energia")]
    public class GsConsumoEnergia
    {
        [Key]
        public int IdConsumo { get; set; }
        public DateTime Data { get; set; }
        public double EnergiaConsumidaKwh { get; set; }
        public int IdConsumidor { get; set; }
        [ForeignKey("IdConsumidor")]
        public GsConsumidor Consumidor { get; set; }
    }
}