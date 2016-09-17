using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using sgi.api.Helpers;
using sgi.api.Mappings;
using sgi.api.Security;
using sgi.domain.Contracts.Services;
using sgi.startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace sgi.api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolver(container);

            ConfigureWebApi(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureOAuth(app, container.Resolve<IUsuarioService>());
                        
            app.UseWebApi(config);

            AutoMapperConfig.RegisterMappings(); 
        }
        public static void ConfigureWebApi(HttpConfiguration config)
        {
            //Remove XML
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            //Modifica a identação
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Modifica a serialização
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

           config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
        public void ConfigureOAuth(IAppBuilder app, IUsuarioService service)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider(service)
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


        }
    }

    public class DynamicContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        private IList<string> _propertiesToSerialize = null;

        public DynamicContractResolver(IList<string> propertiesToSerialize)
        {
            _propertiesToSerialize = propertiesToSerialize;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => _propertiesToSerialize.Contains(p.PropertyName)).ToList();
        }
    }
}