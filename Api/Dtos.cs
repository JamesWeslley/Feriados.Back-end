using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record FeriadoDto(
        [Required] int Id, 
        string Data, 
        [Required] string Titulo, 
        [Required] string Descricao, 
        [Required] string Legislacao, 
        [Required] string Tipo, 
        string HoraInicio, 
        string HoraFim,
        dynamic DatasMoveis);

    public record CriacaoFeriadoDto(
        [StringLength(5)] string Data, 
        [Required] [StringLength(50)] string Titulo, 
        [Required] [StringLength(200)] string Descricao, 
        [Required] [StringLength(200)] string Legislacao, 
        [Required] [StringLength(50)] string Tipo,
        [StringLength(8)] string HoraInicio,
        [StringLength(8)] string HoraFim, 
        dynamic DatasMoveis);

    public record AlteracaoFeriadoDto(
        [StringLength(5)] string Data, 
        [Required] [StringLength(200)] string Descricao, 
        [Required] [StringLength(200)] string Legislacao,
        [Required] [StringLength(50)]string Tipo,
        [StringLength(8)] string HoraInicio,
        [StringLength(8)] string HoraFim, 
        dynamic DatasMoveis);
}