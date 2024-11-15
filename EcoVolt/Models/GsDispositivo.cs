using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_DISPOSITIVO")]
public class GsDispositivo
{
    [Key]
    [Column("ID_DISPOSITIVO")]
    public int IdDispositivo { get; set; }

    [Column("CONSUMO_ENERGIA_KWH")]
    public decimal? ConsumoEnergiaKwh { get; set; }

    [Column("TIPO_DISPOSITIVO")]
    public int? TipoDispositivoId { get; set; }

    [Column("ID_CONSUMIDOR")]
    public int? IdConsumidor { get; set; }
    
    [ForeignKey("TipoDispositivoId")]
    public virtual GsTipoDispositivo TipoDispositivo { get; set; }

    [ForeignKey("IdConsumidor")]
    public virtual GsConsumidor Consumidor { get; set; }
}