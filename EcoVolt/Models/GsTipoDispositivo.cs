using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_tipo_dispositivo")]
    public class GsTipoDispositivo
    {
        [Key]
        public int IdTipoDispositivo { get; set; }
        public string Descricao { get; set; }
        public ICollection<GsDispositivo> Dispositivos { get; set; }
    }
}