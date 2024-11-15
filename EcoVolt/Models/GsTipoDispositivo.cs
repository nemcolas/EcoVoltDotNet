using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_TIPO_DISPOSITIVO")]
public class GsTipoDispositivo
{
    [Key]
    [Column("ID_TIPO_DISPOSITIVO")]
    public int IdTipoDispositivo { get; set; }

    [Column("DESCRICAO")]
    public string Descricao { get; set; }
}