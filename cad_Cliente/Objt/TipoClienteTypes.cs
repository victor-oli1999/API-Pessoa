using System;
using System.Text.Json.Serialization;

namespace API_Pessoa.cad_Cliente.Objt
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoClienteTypes : byte
    {
        Prospect = 1,
        Cliente = 2,
        ContaDeclinada = 3,
        Inativo = 4,
        Trabalhando = 5,
        ContaSonho = 6,
        AgenteNoExterio = 7,
        PreVendas = 8,
        SemInteresseCliente = 9,
        CadastroIncompleto = 10,
        Oportunidade = 11,
        Churn = 12
    }
}
