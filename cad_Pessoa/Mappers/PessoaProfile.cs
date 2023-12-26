using AutoMapper;
using API_Pessoa.cad_Pessoa.Entities;
using API_Pessoa.cad_Pessoa.Models;

namespace API_Pessoa.cad_Pessoa.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaInputModel, Pessoa>();
        }
    }
}
