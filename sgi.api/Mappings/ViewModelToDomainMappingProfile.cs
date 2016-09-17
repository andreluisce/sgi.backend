using AutoMapper;
using sgi.api.Models.ViewModels;
using sgi.domain.Models;

namespace sgi.api.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<PerfilPessoalViewModel, PerfilPessoal>();
            Mapper.CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}
