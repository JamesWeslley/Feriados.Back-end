using Api.Dtos;
using Api.Entidades;
using System.Text.Json;

namespace Api
{
    public static class Extensions
    {
        public static FeriadoDto AsDto(this Feriado feriado)
        {
            return new FeriadoDto(feriado.Id, feriado.Data, feriado.Titulo, feriado.Descricao, feriado.Legislacao, feriado.Tipo, feriado.HoraInicio, feriado.HoraFim, JsonSerializer.Deserialize<dynamic>(feriado.DatasMoveis));
        }
    }
}
