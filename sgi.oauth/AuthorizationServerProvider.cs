using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace sgi.oauth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() =>
                {
                    context.Validated();
                });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() =>
            {
                 context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                 var user = context.UserName;
                 var pass = context.Password;

                 try
                 {
                     if (user != "andre" || pass != "1234")
                     {
                         context.SetError("invalid_grant", "Usuário ou Senha incorretos.");
                         return;
                     }

                     var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                     identity.AddClaim(new Claim(ClaimTypes.Name, user));

                     var roles = new List<string>();
                     //roles.Add("Admin");
                     roles.Add("User");

                     foreach (var role in roles)
                     {
                         identity.AddClaim(new Claim(ClaimTypes.Role, role));
                     }

                     GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                     Thread.CurrentPrincipal = principal;

                     context.Validated(identity);
                 }

                 catch (System.Exception)
                 {
                     context.SetError("invalid_grant", "Falha ao autenticar");
                 }
            });
        }
    }

}