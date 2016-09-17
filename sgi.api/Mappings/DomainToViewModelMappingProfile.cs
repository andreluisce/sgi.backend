using AutoMapper;
using sgi.api.Models.ViewModels;
using sgi.domain.Models;

namespace sgi.api.Mappings
{
  public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
      
        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Usuario, UsuarioCreateMenuModel>();
            Mapper.CreateMap<PerfilPessoal, PerfilPessoalViewModel>();
            Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<Cidade, CidadeViewModel>();
            Mapper.CreateMap<Estado, EstadoViewModel>();
            Mapper.CreateMap<Estado, EstadoInstituicaoViewModel>();
            Mapper.CreateMap<Pais, PaisViewModel>();
            Mapper.CreateMap<Modulo, ModuloViewModel>();
            Mapper.CreateMap<Modulo, SubModuloViewModel>();
            Mapper.CreateMap<Acao, AcaoViewModel>();
            Mapper.CreateMap<Regra, RegraViewModel>();
            Mapper.CreateMap<Igreja, IgrejaViewModel>();
            Mapper.CreateMap<Igreja, IgrejaInstituicaoViewModel>();
            Mapper.CreateMap<PerfilIgreja, PerfilIgrejaViewModel>();
            Mapper.CreateMap<Denominacao, DenominacaoViewModel>();
            Mapper.CreateMap<Regiao, RegiaoViewModel>();
            Mapper.CreateMap<Distrito, DistritoViewModel>();
        }
    }
}
