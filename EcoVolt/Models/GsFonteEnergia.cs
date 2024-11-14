using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models
{
    [Table("gs_fonte_energia")]
    public class GsFonteEnergia
    {
        [Key]
        public int IdFonte { get; set; }
        public string NomeFonte { get; set; }
        public int IdTipoFonte { get; set; }
        [ForeignKey("IdTipoFonte")]
        public GsTipoFonte TipoFonte { get; set; }
        public ICollection<GsGeracaoEnergia> GeracoesEnergia { get; set; }
    }
}