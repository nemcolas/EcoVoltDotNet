using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_CONSUMO_ENERGIA")]
public class GsConsumoEnergia
{
    [Key]
    [Column("ID_CONSUMO")]
    public int IdConsumo { get; set; }

    [Column("ENERGIA_CONSUMIDA_KWH")]
    public decimal? EnergiaConsumidaKwh { get; set; }

    [Column("DATA")]
    public DateTime? Data { get; set; }

    [Column("ID_CONSUMIDOR")]
    public int? IdConsumidor { get; set; }
    
    [ForeignKey("IdConsumidor")]
    public virtual GsConsumidor Consumidor { get; set; }
}