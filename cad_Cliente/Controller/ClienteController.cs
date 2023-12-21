using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Pessoa.cad_Cliente.Entities;
using API_Pessoa.cad_Cliente.Persistence;

namespace API_Pessoa.cad_Cliente.Controller
{
    [Route("api")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ClienteController(ClienteContext context)
        {
            _context = context;
        }

        [HttpGet("Clientes")]
        public List<Cliente> Clientes()
        {
            var Clientes = _context.Clientes.ToList();

            return Clientes;
        }
        [HttpGet("Clientes/{id}")]
        public async Task<IActionResult> Cliente(int id)
        {
            var clientesPorID = await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

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
