using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_CIDADE")]
public class GsCidade
{
    [Key]
    [Column("COD_CIDADE")]
    public int CodCidade { get; set; }

    [Column("NOM_CIDADE")]
    public string NomCidade { get; set; }

    [Column("COD_ESTADO")]
    public int CodEstado { get; set; }

 
    [ForeignKey("CodEstado")]
    public virtual GsEstado Estado { get; set; }
}