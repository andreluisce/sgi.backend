using AutoMapper;
using sgi.api.Models.Usuario;
using sgi.domain.Models;

namespace sgi.api.Mappers
{
    class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName  { get { return "DomainToViewModelMappings"; }}        
        protected override void Configure() {

            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            /*
            Mapper.CreateMap<Usuario, UsuarioViewModel>().ForMember(p => p.Perfil, o => o.UseDestinationValue())
            .ForAllMembers(n => n.Condition(sr => ! sr.IsSourceValueNull)); 
           Mapper.CreateMap<Usuario, UsuarioViewModel>();


           Mapper.CreateMap<Usuario, UsuarioViewModel>().ForMember(dest => dest.Perfil, opt => opt.MapFrom(per => Mapper.Map<Usuario, UsuarioViewModel>(per))); 
            */
            /*Mapper.CreateMap<Usuario, Perfil>().ForMember(p => p.Usuario, opt => opt.ToString());

            Mapper.CreateMap<UsuarioViewModel, Usuario>()
    .ForMember(dto => dto.Perfil, opt => opt.);*/

            //dto => dto.Perfil, options => options.MapFrom(perfil => Mapper.Map<Usuario, Perfil>(perfil))
        
        }
    }
}
