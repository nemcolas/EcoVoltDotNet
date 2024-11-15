using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVolt.Models;

[Table("GS_FONTE_ENERGIA")]
public class GsFonteEnergia
{
    [Key]
    [Column("ID_FONTE")]
    public int IdFonte { get; set; }

    [Column("GERACAO_ENERGIA_KWH")]
    public decimal? GeracaoEnergiaKwh { get; set; }

    [Column("CAPACIDADE_BATERIA_KWH")]
    public decimal? CapacidadeBateriaKwh { get; set; }

    [Column("ID_TIPO_FONTE")]
    public int? IdTipoFonte { get; set; }

    [Column("ID_LOCALIZACAO")]
    public int? IdLocalizacao { get; set; }

    // Propriedades de navegação para as relações com o tipo de fonte e a localização
    [ForeignKey("IdTipoFonte")]
    public virtual GsTipoFonte TipoFonte { get; set; }

    [ForeignKey("IdLocalizacao")]
    public virtual GsLocalizacao Localizacao { get; set; }
}