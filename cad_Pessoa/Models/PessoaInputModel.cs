using System.ComponentModel.DataAnnotations;

namespace API_Pessoa.cad_Pessoa.Models
{
    public class PessoaInputModel
    {
        public int IdUsuario_Criacao { get; set; }
        public string Nome { get; set; }
        public string? Nome_Fantasia { get; set; }
        [Range(1, 3)]
        public byte Tipo { get; set; }
        public bool Tipo_Pessoa { get; set; }
        public string? Cpf_Cnpj { get; set; }
        public string? Fone { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public short? IdMunicipio { get; set; }
        public short? IdUnidade_Federativa { get; set; }
        public short? IdPais { get; set; }
    }
}
