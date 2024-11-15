using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_CONSUMIDOR")]
public class GsConsumidor
{
    [Key]
    [Column("ID_CONSUMIDOR")]
    public int IdConsumidor { get; set; }

    [Column("ENERGIA_ATRIBUIDA_KWH")]
    public decimal? EnergiaAtribuidaKwh { get; set; }

    [Column("NIVEL_PRIORIDADE")]
    public string NivelPrioridade { get; set; }

    [Column("ID_TIPO_CONSUMIDOR")]
    public int? IdTipoConsumidor { get; set; }

    [Column("ID_LOCALIZACAO")]
    public int? IdLocalizacao { get; set; }
    
    [ForeignKey("IdTipoConsumidor")]
    public virtual GsTipoConsumidor TipoConsumidor { get; set; }

    [ForeignKey("IdLocalizacao")]
    public virtual GsLocalizacao Localizacao { get; set; }
}