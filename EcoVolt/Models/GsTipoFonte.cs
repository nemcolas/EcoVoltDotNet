using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

public class GsTipoFonte
{
    [Key]
    [Column("ID_TIPO_FONTE")]
    public int IdTipoFonte { get; set; }

    [Column("DESCRICAO")]
    public string Descricao { get; set; }
}