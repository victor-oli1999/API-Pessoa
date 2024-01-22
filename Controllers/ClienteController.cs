using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Pessoa.Core.Entities;
using API_Pessoa.Data.Context;


namespace API_Pessoa.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DBContext _context;

        public ClienteController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("Clientes")]
        public List<Cliente> Clientes()
        {
            var Clientes = _context.Set<Cliente>().ToList();

            return Clientes;
        }
        [HttpGet("Clientes/{id}")]
        public async Task<IActionResult> Cliente(int id)
        {
            var clientesPorID = await _context.Set<Cliente>().FirstOrDefaultAsync(x => x.IdCliente == id);

            if (clientesPorID == null)
                return NotFound(new { Error = "Cliente não encontrado." });

            return Ok(clientesPorID);
        }





        /* Utilizar como base para inserir demais cadastros */
        //[HttpGet("Teste")]
        //public async Task<IActionResult> Teste()
        //{
        //    var test = Clientes();
        //    return Ok(test);
        //}
    }
}
