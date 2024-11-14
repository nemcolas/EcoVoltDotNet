using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_tipo_fonte")]
    public class GsTipoFonte
    {
        [Key]
        public int IdTipoFonte { get; set; }
        public string Descricao { get; set; }
        public ICollection<GsFonteEnergia> FontesEnergia { get; set; }
    }
}