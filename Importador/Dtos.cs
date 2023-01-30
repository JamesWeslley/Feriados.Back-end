namespace Importador.Dtos
{
    public record FeriadoOrigemDto(string date, string title, string description, string legislation, string type, string startTime, string endTime, dynamic variableDates);

    public record FeriadoDestinoDto(string Data, string Titulo, string Descricao, string Legislacao, string Tipo, string HoraInicio, string HoraFim, dynamic DatasMoveis);
}