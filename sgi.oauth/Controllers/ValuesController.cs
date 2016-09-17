using System.Web.Http;

namespace sgi.oauth.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize(Roles="User")]
        public string Get()
        {
            return User.Identity.Name; 
        }
    }
}
