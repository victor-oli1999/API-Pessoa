using API_Pessoa.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Pessoa.Entities;

namespace API_Pessoa.Controllers
{
    [Route("api")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaContext _context;

        public PessoaController(PessoaContext context)
        {
            _context = context;
        }

        [HttpGet("Pessoas")]
        public List<Pessoa> Pessoas()
        {
            var Pessoas = _context.Pessoas.ToList();

            return Pessoas;
        }
        [HttpGet("Pessoas/{id}")]
        public async Task<IActionResult> Pessoa(int id)
        {
            var pessoaPorID = await _context.Pessoas.FirstOrDefaultAsync(x => x.IdPessoa == id);

            if (pessoaPorID == null)
                return NotFound(new { Error = "Pessoa não encontrada." });

            return Ok(pessoaPorID);
        }





        /* Utilizar como base para inserir demais cadastros */
        [HttpGet("Teste")]
        public async Task<IActionResult> Teste()
        {
            var test = Pessoas();
            return Ok(test);
        }
    }
}
