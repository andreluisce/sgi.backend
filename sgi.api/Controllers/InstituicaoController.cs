using AutoMapper;
using sgi.api.Attributes;
using sgi.api.Helpers;
using sgi.api.Models.ViewModels;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace sgi.api.Controllers
{
    [RoutePrefix("v1/instituicao")]
    public class InstituicaoController : ApiController
    {
        private IInstituicaoService _instituicaoService;
        private ControllerResponseHelper _responseMessage;

        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
            _responseMessage = new ControllerResponseHelper(Request);
        }

        [HttpGet]
        [DeflateCompression]        
        [Route("obterdenominacoes")]        
        public Task<HttpResponseMessage> ObterDenominacoes()
        {

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Denominacao>, List<DenominacaoViewModel>>(_instituicaoService.ObterDenominacoes()));
            }

            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);

        }

        [HttpGet]
        [DeflateCompression]        
        [Route("obterregioes/{denominacaoid}")]
        public Task<HttpResponseMessage> ObterRegioes(int denominacaoid)
        {

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Regiao>, List<RegiaoViewModel>>(_instituicaoService.ObterRegioes(denominacaoid)));
            }

            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);

        }

        [HttpGet]
        [DeflateCompression]
        [Route("obterestados/{regiaoid}")]
        public Task<HttpResponseMessage> ObterEstados(int regiaoid)
        {

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Estado>, List<EstadoInstituicaoViewModel>>(_instituicaoService.ObterEstados(regiaoid)));
            }

            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);

        }

        [HttpGet]
        [DeflateCompression]        
        [Route("obterdistritos/{estadoid}")]
        public Task<HttpResponseMessage> ObterDistritos(int estadoid)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Distrito>, List<DistritoViewModel>>(_instituicaoService.ObterDistritos(estadoid)));
            }

            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);

        }

        [HttpGet]
        [DeflateCompression]
        [Route("obterigrejas/{distritoid}")]
        public Task<HttpResponseMessage> ObterIgrejas(int distritoid)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Igreja>, List<IgrejaInstituicaoViewModel>>(_instituicaoService.ObterIgrejas(distritoid)));
            }

            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpGet]
        [DeflateCompression]
        [Route("obtercidades/{distritoid}")]
        public Task<HttpResponseMessage> ObterCidades(int distritoid)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Cidade>, List<CidadeViewModel>>(_instituicaoService.ObterCidades(distritoid)));
            }

            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpGet]
        [DeflateCompression]
        [Route("modeligreja")]
        public Task<HttpResponseMessage> ModelIgreja()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new IgrejaInstituicaoViewModel());
            }

            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpPost]
        [Route("cadastrarigreja")]
        public Task<HttpResponseMessage> CadastrarIgreja(Igreja model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var igreja = Mapper.Map<Igreja>(model);
                //igreja.Endereco.TipoEndereco = domain.Models.Enum.TipoEndereco.Igreja;
                _instituicaoService.CadastrarIgreja(igreja);
            }

            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }
            return _responseMessage.ApiResponse(response);
        }

        protected override void Dispose(bool disposing)
        {
            _instituicaoService.Dispose();
        }

        private Task<HttpResponseMessage> ApiResponse(HttpResponseMessage response)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
