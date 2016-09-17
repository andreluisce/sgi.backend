using AutoMapper;
using sgi.api.Models.Usuario;
using sgi.domain.Models;
namespace sgi.api.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                 {

                     x.AddProfile<DomainToViewModelMappingProfile>();
                     x.AddProfile<ViewModelToDomainMappingProfile>();

                 });

           

        }
    }
}