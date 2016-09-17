using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace sgi.api.Helpers
{
    public class ControllerResponseHelper
    {
        private bool _debug;
        private HttpRequestMessage _request;

        public ControllerResponseHelper(HttpRequestMessage Request)
        {
            this._request = Request;
            this.CheckDebugHeader(); 
        }
        private void CheckDebugHeader()
        {
            try
            {
                this._request.Headers.GetValues("Debug");
                this._debug = true;
            }
            catch (Exception)
            {
                this._debug = false;
            }            
        }

        public HttpResponseMessage CreateExceptionMessage(Exception ex)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            if (!this._debug)
                response = this._request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            else
                response = this._request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());

            return response;
        }

        public Task<HttpResponseMessage> ApiResponse(HttpResponseMessage response)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}