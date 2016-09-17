using AutoMapper;
using sgi.api.Attributes;
using sgi.api.Models.ViewModels;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace sgi.api.Controllers
{
    [RoutePrefix("v1/menu")]
    public class MenuController : ApiController
    {
        private IUsuarioService _usuarioService;

        public MenuController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        [Route("montarmenu")]
        [Authorize()]
        public Task<HttpResponseMessage> MontarMenu()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var claimsId = (ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity;

            try
            {

                var r = this._usuarioService.MontarMenu(claimsId.Name);
                //var x1 = r.Regra.Acoes.Select(x => new {Modulo = x.Modulo.Nome, Acoes = x.}); 

                /*var x3 = from modulo in r.Regra.Modulos
                         join regra in r.Regra.Acoes
                         on */





                bool listaValida = false;
                if (r.Regra.Modulos.Any(x => x.Acoes.Count > 0))
                {
                    listaValida = true;
                }else if(r.Regra.Modulos.Any(x => x.Submodulos.Count > 0) && r.Regra.Modulos.Any(x => x.Submodulos.Any(z => z.Acoes.Count > 0))){
                    listaValida = true;
                }

                if (listaValida)
                {
                    //var resp = r.Regra.Modulos.Select(x => new { Id = x.Id, Modulo = x.Nome, CssClass = x.CssClass, Acoes = x.Acoes.Select(y => new { y.Nome, y.Route }).OrderBy(z => z.Nome), Submodulos = x.Submodulos.Select(s => new { Id = s.Id, Modulo = s.Nome, CssClass = s.CssClass, Acoes = s.Acoes.Select(a => new { a.Nome, a.Route }).OrderBy(b => b.Nome) }) }).OrderBy(w => w.Modulo);


                    response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Usuario, UsuarioCreateMenuModel>(r));
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.OK, new ArrayList());




            }
            catch (Exception ex)
            {

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return ApiResponse(response);
        }

        protected override void Dispose(bool disposing)
        {
            _usuarioService.Dispose();
        }

        private Task<HttpResponseMessage> ApiResponse(HttpResponseMessage response)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
