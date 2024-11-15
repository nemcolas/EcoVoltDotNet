using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_TIPO_CONSUMIDOR")]
public class GsTipoConsumidor
{
    [Key]
    [Column("ID_TIPO_CONSUMIDOR")]
    public int IdTipoConsumidor { get; set; }

    [Column("DESCRICAO")]
    public string Descricao { get; set; }
}