using Importador.Dtos;

namespace importador
{
    public static class Extensions
    {
        public static FeriadoDestinoDto AsFeriadoDestinoDto(this FeriadoOrigemDto feriado)
        {
            return new FeriadoDestinoDto(feriado.date, feriado.title, feriado.description, feriado.legislation, feriado.type, feriado.startTime, feriado.endTime, feriado.variableDates);
        }
    }
}
