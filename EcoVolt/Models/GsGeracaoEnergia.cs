using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_GERACAO_ENERGIA")]
public class GsGeracaoEnergia
{
    [Key]
    [Column("ID_GERACAO")]
    public int IdGeracao { get; set; }

    [Column("ENERGIA_GERADA_KWH")]
    public decimal? EnergiaGeradaKwh { get; set; }

    [Column("DATA")]
    public DateTime? Data { get; set; }

    [Column("ID_FONTE")]
    public int? IdFonte { get; set; }
    
    [ForeignKey("IdFonte")]
    public virtual GsFonteEnergia Fonte { get; set; }
}