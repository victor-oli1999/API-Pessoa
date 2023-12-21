using System.Runtime.ConstrainedExecution;
using System;
using API_Pessoa.cad_Cliente.Objt;

namespace API_Pessoa.cad_Cliente.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int? IdFuncionario_Responsavel { get; set; }
        public int? IdVendedor_Responsavel { get; set; }
        public TipoClienteTypes Tipo_Cliente { get; set; }
        public bool Cliente_ { get; set; }
        public bool Importador_ { get; set; }
        public bool Exportador_ { get; set; }
    }
}
