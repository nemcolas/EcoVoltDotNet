using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_BAIRRO")]
public class GsBairro
{
    [Key]
    [Column("COD_BAIRRO")]
    public int CodBairro { get; set; }

    [Column("NOME")]
    public string Nome { get; set; }

    [Column("COD_CIDADE")]
    public int CodCidade { get; set; }
    
    [ForeignKey("CodCidade")]
    public virtual GsCidade Cidade { get; set; }
}