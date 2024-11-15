using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_PAIS")]
public class GsPais
{
    [Key]
    [Column("COD_PAIS")]
    public int CodPais { get; set; }

    [Column("NOM_PAIS")]
    public string NomPais { get; set; }
}