using AutoMapper;
using sgi.api.Attributes;
using sgi.api.Helpers;
using sgi.api.Models.UsuarioModel;
using sgi.api.Models.ViewModels;
using sgi.common.Resources;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace sgi.api.Controllers
{
    [RoutePrefix("v1/usuarios")]
    public class UsuarioController : ApiController
    {
        private IUsuarioService _service;
        private ControllerResponseHelper _responseMessage;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
            _responseMessage = new ControllerResponseHelper(Request); 
   
        }

        [HttpGet]
        [Route("")]
        //[DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Usuario>, List<UsuarioViewModel>>(_service.GetByRange(0, 25)));
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpGet]
        [Route("email/{email}")]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> GetByEmail(string email)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Usuario, UsuarioViewModel>(_service.Obter(email)));
            }
            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [Route("id/{id}")]
        [HttpGet]
        public Task<HttpResponseMessage> GetById(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Usuario, UsuarioViewModel>(_service.Obter(id)));
            }
            catch (Exception ex)
            {

                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpGet]
        [Authorize()]
        [DeflateCompression]
        [Route("islogged")]
        public Task<HttpResponseMessage> IsLogged()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.IsLogged);
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Register(Usuario model)
        {
            //Para Registrar um usuário é necessário ter um perfil com endereço.
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                //Limpando possíveis propriedades injetadas
                model.Id = 0;
                _service.Registrar(model);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome, email = model.Email });
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }
            return _responseMessage.ApiResponse(response);
        }

        [Authorize(Roles="Administrador,Usuário")]
        [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> ChangeInformation(Usuario model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var identity = User.Identity as ClaimsIdentity;
 
            var items = identity.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            }).FirstOrDefault();
        


            try
            {
                _service.MudarInformacao(User.Identity.Name, model.Nome);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome });
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpPost]
        [Route("atualizar")]
        public Task<HttpResponseMessage> UpdateInformation(Usuario usuario)
        {
            HttpResponseMessage response = new HttpResponseMessage();

                   try
            {
                _service.Atualizar(usuario);
                response = Request.CreateResponse(HttpStatusCode.OK, "Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [Authorize]
        [HttpPost]
        [Route("mudarsenha")]
        public Task<HttpResponseMessage> ChangePassword(MudarSenhaModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _service.MudarSenha(User.Identity.Name, model.Senha, model.NovaSenha, model.ConfirmarNovaSenha);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.PasswordSuccessfulyChanges);
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpPost]
        [Route("resetarsenha")]
        public Task<HttpResponseMessage> ResetPassword(Usuario model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var password = _service.ResetarSenha(model.Email);
                response = Request.CreateResponse(HttpStatusCode.OK, String.Format(Messages.ResetPasswordEmailBody, password));
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        [HttpPost]
        [Route("associarusuarioregra")]
        public Task<HttpResponseMessage> AssociarUsuarioRegra(AssociarUsuarioRegraModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.AssociarUsuarioRegra(model.usuario, model.regra);
                response = Request.CreateResponse(HttpStatusCode.OK, String.Format(Messages.UserRoleAssociated, model.usuario));
            }
            catch (Exception ex)
            {
                response = _responseMessage.CreateExceptionMessage(ex);
            }

            return _responseMessage.ApiResponse(response);
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
