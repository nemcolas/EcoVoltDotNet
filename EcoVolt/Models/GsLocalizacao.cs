using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_LOCALIZACAO")]
public class GsLocalizacao
{
    [Key]
    [Column("ID_LOCALIZACAO")]
    public int IdLocalizacao { get; set; }

    [Column("LATITUDE")]
    public decimal Latitude { get; set; }

    [Column("LONGITUDE")]
    public decimal Longitude { get; set; }

    [Column("ENDERECO_COMPLETO")]
    public string EnderecoCompleto { get; set; }

    [Column("COD_BAIRRO")]
    public int CodBairro { get; set; }
    
    [ForeignKey("CodBairro")]
    public virtual GsBairro Bairro { get; set; }
}