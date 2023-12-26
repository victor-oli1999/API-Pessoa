using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Pessoa.cad_Pessoa.Entities;
using API_Pessoa.cad_Pessoa.Persistence;
using API_Pessoa.cad_Pessoa.Models;
using API_Pessoa.cad_Pessoa.Mappers;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using System.Collections;

namespace API_Pessoa.cad_Pessoa.Controllers
{
    [Route("api")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaContext _context;
        private readonly IMapper _mapper;

        public PessoaController(PessoaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        [HttpPost("Pessoa/Insert")]
        public IActionResult InsertPessoa(PessoaInputModel input)
        {
            var pessoaInput = _mapper.Map<Pessoa>(input);

            pessoaInput.IdPessoa = novoIdPessoa();
            pessoaInput.Codigo = novoCodigo();
            pessoaInput.Data_Criacao = PegaHoraBrasilia();
            pessoaInput.Ativo = true;

            if (pessoaInput.IdPais == 0)
            {
                pessoaInput.IdPais = null;
            } 
            if (pessoaInput.IdUnidade_Federativa == 0) 
            {
                pessoaInput.IdUnidade_Federativa = null;
            } 
            if (pessoaInput.IdMunicipio == 0)
            {
                pessoaInput.IdMunicipio = null;
            }

            _context.Pessoas.Add(pessoaInput);
            _context.SaveChanges();

            return Ok(pessoaInput);
        }



        /* Complementar */
        [HttpGet("Pessoa/novoIdPessoa")]
        public int novoIdPessoa()
        {
            var ultimoIdPessoa = _context.Pessoas.OrderBy(x => x.IdPessoa).LastOrDefault();
            int novoIdPessoa = ultimoIdPessoa.IdPessoa + 1;

            return novoIdPessoa;
        }

        [HttpGet("PegaHoraBrasilia")]
        public DateTime PegaHoraBrasilia() => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        
        [HttpGet("Pessoa/novoCodigo")]
        public string novoCodigo()
        {
            string codigo;
            switch (novoIdPessoa().ToString().Length)
            {
                case 1:
                    codigo = "00000" + novoIdPessoa();
                    break;
                case 2:
                    codigo = "0000" + novoIdPessoa();
                    break;
                case 3:
                    codigo = "000" + novoIdPessoa();
                    break;
                case 4:
                    codigo = "00" + novoIdPessoa();
                    break;
                case 5:
                    codigo = "0" + novoIdPessoa();
                    break;
                default:
                    codigo = novoIdPessoa().ToString();
                    break;
            }
            return codigo;
        }
        [HttpGet("Pessoa/{cpfCnpj}")]
        public IEnumerable VerificaCpfCnpj(string cpfCnpj)
        {
            IEnumerable teste = _context.Pessoas.Where(x => x.Cpf_Cnpj == cpfCnpj.ToString()).ToList();

            return teste;
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
