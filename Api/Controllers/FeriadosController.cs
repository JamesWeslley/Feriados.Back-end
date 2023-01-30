using Api.Dados;
using Api.Dtos;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("feriados")]
    [ApiController]
    public class FeriadosController : ControllerBase
    {
        private readonly IFeriadoDao _feriadoDao;
        public FeriadosController(IFeriadoDao feriadoDao) {
            _feriadoDao = feriadoDao;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeriadoDto>>> GetAsync()
        {
            var feriados = (await _feriadoDao.ObterTodosAsync())
                .Select(feriado => feriado.AsDto());

            return Ok(feriados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeriadoDto>> GetAsync(int id)
        {
            var item = await _feriadoDao.ObterPorIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult<FeriadoDto>> PostAsync(CriacaoFeriadoDto criacaoFeriadoDto)
        {
            var feriadoJaCadastrado = (await _feriadoDao.ObterTodosAsync()).Any(f => f.Titulo == criacaoFeriadoDto.Titulo); ;
            if (feriadoJaCadastrado)
            {
                return BadRequest($"Já existe um feriado com o título {criacaoFeriadoDto.Titulo}.");
            }

            var feriado = new Feriado
            {
                Data = criacaoFeriadoDto.Data,
                Titulo = criacaoFeriadoDto.Titulo,
                Descricao = criacaoFeriadoDto.Descricao,
                Legislacao = criacaoFeriadoDto.Legislacao,
                Tipo = criacaoFeriadoDto.Tipo,
                HoraInicio = criacaoFeriadoDto.HoraInicio,
                HoraFim = criacaoFeriadoDto.HoraFim,
                DatasMoveis = criacaoFeriadoDto.DatasMoveis.ToString()
            };

            await _feriadoDao.InserirAsync(feriado);

            return CreatedAtAction(nameof(GetAsync), new { id = feriado.Id }, feriado);
        }

        [HttpPost]
        [Route("bulk")]
        public async Task<IActionResult> PostAsync(IEnumerable<CriacaoFeriadoDto> feriados)
        {
            var novosFeriados = feriados.Select(feriado => new Feriado
            {
                Data = feriado.Data,
                Titulo = feriado.Titulo,
                Descricao = feriado.Descricao,
                Legislacao = feriado.Legislacao,
                Tipo = feriado.Tipo,
                HoraInicio = feriado.HoraInicio,
                HoraFim = feriado.HoraFim,
                DatasMoveis = feriado.DatasMoveis.ToString()
            });

            await _feriadoDao.InserirAsync(novosFeriados);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, AlteracaoFeriadoDto alteracaoFeriadoDto)
        {
            var feriadoExistente = await _feriadoDao.ObterPorIdAsync(id);

            if (feriadoExistente == null)
            {
                return NotFound();
            }

            feriadoExistente.Data = alteracaoFeriadoDto.Data;
            feriadoExistente.Descricao = alteracaoFeriadoDto.Descricao;
            feriadoExistente.Legislacao = alteracaoFeriadoDto.Legislacao;
            feriadoExistente.Tipo = alteracaoFeriadoDto.Tipo;
            feriadoExistente.HoraInicio = alteracaoFeriadoDto.HoraInicio;
            feriadoExistente.HoraFim = alteracaoFeriadoDto.HoraFim;
            feriadoExistente.DatasMoveis = alteracaoFeriadoDto.DatasMoveis.ToString();

            await _feriadoDao.AlterarAsync(feriadoExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var feriadoExistente = await _feriadoDao.ObterPorIdAsync(id);

            if (feriadoExistente == null)
            {
                return NotFound();
            }

            await _feriadoDao.DeletarAsync(id);

            return NoContent();

        }
    }
}
