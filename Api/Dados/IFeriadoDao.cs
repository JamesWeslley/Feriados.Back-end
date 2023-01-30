using Api.Entidades;

namespace Api.Dados
{
    public interface IFeriadoDao
    {
        Task<IEnumerable<Feriado>> ObterTodosAsync();
        Task<Feriado?> ObterPorIdAsync(int id);
        Task InserirAsync(Feriado feriado);
        Task InserirAsync(IEnumerable<Feriado> feriados);
        Task AlterarAsync(Feriado feriado);
        Task DeletarAsync(int id);
        
    }
}
