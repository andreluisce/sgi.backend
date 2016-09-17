using AutoMapper;
using sgi.api.Models.Usuario;
using sgi.domain.Models;

namespace sgi.api.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {        
            public override string ProfileName { get { return "ViewModelToDomainMappings"; } }
            protected override void Configure() { Mapper.CreateMap<UsuarioViewModel, Usuario>(); }        
    }
}
