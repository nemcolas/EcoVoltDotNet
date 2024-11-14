using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_dispositivo")]
    public class GsDispositivo
    {
        [Key]
        public int IdDispositivo { get; set; }
        public string NomeDispositivo { get; set; }
        public int IdTipoDispositivo { get; set; }
        [ForeignKey("IdTipoDispositivo")]
        public GsTipoDispositivo TipoDispositivo { get; set; }
        public int IdConsumidor { get; set; }
        [ForeignKey("IdConsumidor")]
        public GsConsumidor Consumidor { get; set; }
    }
}