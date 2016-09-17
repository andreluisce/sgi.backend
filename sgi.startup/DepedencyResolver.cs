using Microsoft.Practices.Unity;
using sgi.business.Services;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using sgi.infra.Data;
using sgi.infra.Data.Repositories;

namespace sgi.startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //Resolver para o DataContext
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            
            //Resolver para o tipo User
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<Usuario, Usuario>(new HierarchicalLifetimeManager());

            //Resolver para o tipo Role
            container.RegisterType<IRegraRepository, RegraRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRegraService, RoleService>(new HierarchicalLifetimeManager());
            container.RegisterType<Regra, Regra>(new HierarchicalLifetimeManager());

            //Resolver para o tipo Module
            container.RegisterType<IModuloRepository, ModuloRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IModuloService, ModuloService>(new HierarchicalLifetimeManager());
            container.RegisterType<Modulo, Modulo>(new HierarchicalLifetimeManager());

            //Resolver para o tipo Action
            container.RegisterType<IAcaoRepository, AcaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAcaoService, AcaoService>(new HierarchicalLifetimeManager());
            container.RegisterType<Acao, Acao>(new HierarchicalLifetimeManager());

            //Resolver para o tipo Localizacao
            container.RegisterType<ILocalizacaoRepository, LocalizacaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILocalizacaoService, LocalizacaoService>(new HierarchicalLifetimeManager());

            //Resolver para o tipo Instituicao
            container.RegisterType<IInstituicaoRepository, InstituicaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IInstituicaoService, InstituicaoService>(new HierarchicalLifetimeManager());
        }
    }
}
