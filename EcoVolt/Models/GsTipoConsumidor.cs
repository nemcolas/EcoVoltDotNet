using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_tipo_consumidor")]
    public class GsTipoConsumidor
    {
        [Key]
        public int IdTipoConsumidor { get; set; }
        public string Descricao { get; set; }
        public ICollection<GsConsumidor> Consumidores { get; set; }
    }
}