using Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.Dados.EfCore
{
    public class FeriadoDao : IFeriadoDao
    {
        private readonly AppDbContext _context;

        public FeriadoDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feriado>> ObterTodosAsync()
        {
            return await _context.Feriados.ToListAsync();
        }

        public async Task<Feriado?> ObterPorIdAsync(int id)
        {
            return await _context.Feriados.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task InserirAsync(Feriado feriado)
        {
            if (feriado == null)
                throw new ArgumentNullException(nameof(feriado));

            _context.Feriados.Add(feriado);
            await _context.SaveChangesAsync();
        }

        public async Task InserirAsync(IEnumerable<Feriado> feriados)
        {
            var novosFeriados = feriados.Where(f => !_context.Feriados.Any(bd => bd.Titulo == f.Titulo));
            _context.Feriados.AddRange(novosFeriados);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarAsync(Feriado feriado)
        {
            if (feriado == null)
                throw new ArgumentNullException(nameof(feriado));

            Feriado? feriadoExistente = _context.Feriados.FirstOrDefault(f => f.Id == feriado.Id);
            if (feriadoExistente == null)
                throw new Exception("Elemento não encontrado");

            feriadoExistente.Data = feriado.Data;
            feriadoExistente.Descricao = feriado.Descricao;
            feriadoExistente.Legislacao = feriado.Legislacao;
            feriadoExistente.Tipo = feriado.Tipo;
            feriadoExistente.HoraInicio= feriado.HoraInicio;
            feriadoExistente.HoraFim = feriado.HoraFim;
            feriadoExistente.DatasMoveis = feriado.DatasMoveis;

            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            Feriado? feriadoExistente = _context.Feriados.FirstOrDefault(f => f.Id == id);
            if (feriadoExistente == null)
                throw new Exception("Elemento não encontrado");

            _context.Feriados.Remove(feriadoExistente);
            await _context.SaveChangesAsync();
        }
    }
}
