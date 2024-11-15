using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_ESTADO")]
public class GsEstado
{
    [Key]
    [Column("COD_ESTADO")]
    public int CodEstado { get; set; }

    [Column("NOM_ESTADO")]
    public string NomEstado { get; set; }

    [Column("COD_PAIS")]
    public int CodPais { get; set; }
    
    [ForeignKey("CodPais")]
    public virtual GsPais Pais { get; set; }
}