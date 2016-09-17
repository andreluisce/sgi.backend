using AutoMapper;
using sgi.api.Attributes;
using sgi.api.Helpers;
using sgi.api.Models.ViewModels;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace sgi.api.Controllers
{
     [RoutePrefix("v1/localizacao")]
    public class LocalizacaoController : ApiController
    {
        private ILocalizacaoService _service;
        private ControllerResponseHelper _responseMessage;

        public LocalizacaoController(ILocalizacaoService localizacaoService)
        {
            _service = localizacaoService;
            _responseMessage = new ControllerResponseHelper(Request); 
        }

        [HttpGet]
        [Route("obterpaises")]
        [DeflateCompression]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> GetPaises()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Pais>, List<PaisViewModel>>(_service.ObterPaises()));
            }
            catch (Exception ex)
            {
                response = response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpGet]
        [Route("obterestados/{paisId}")]
        [DeflateCompression]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> GetEstados(int paisId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Estado>, List<EstadoViewModel>>(_service.ObterEstados(paisId)));
            }
            catch (Exception ex)
            {
                response = response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpGet]
        [Route("obtercidades/{estadoId}")]
        [DeflateCompression]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> GetCidades(int estadoId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Cidade>, List<CidadeViewModel>>(_service.ObterCidades(estadoId)));
            }
            catch (Exception ex)
            {
                response = response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }


         protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
