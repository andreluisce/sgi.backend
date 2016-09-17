using sgi.api.Attributes;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace sgi.api.Controllers
{
     [RoutePrefix("v1/modulos")]
    public class ModuloController : ApiController
    {
        private IModuloService _service;

        public ModuloController(IModuloService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
       // [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        // [Authorize(Roles = "Administrador")]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result =  (from a in _service.ObterTodos()
                 select new Regra
                 {
                     Id = a.Id,
                     Nome = a.Nome
                 }).ToList().OrderBy(x => x.Nome);

                response = Request.CreateResponse(HttpStatusCode.OK, _service.ObterTodos());

            }
            catch (Exception ex)
            {

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return ApiResponse(response);
        }

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Register(Modulo model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Registrar(model);

                response = Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return ApiResponse(response);
        }

       /* [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> ChangeName(Acao model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.MudarNome(model.Nome, model.NovoNome);
                response = Request.CreateResponse(HttpStatusCode.OK, new { NewName = model.NovoNome });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return ApiResponse(response);
        }
        */
        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }

        private Task<HttpResponseMessage> ApiResponse(HttpResponseMessage response)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
