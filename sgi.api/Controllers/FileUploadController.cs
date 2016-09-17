using Newtonsoft.Json;
using sgi.api.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace sgi.api.Controllers
{
    [RoutePrefix("v1/fileupload")]
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            
            string finalfile = "";
            try
            {

                //Model dos dados do form
                var modelDef = new {igrejaId = 0, denominacaoId = 0, filename = "", email = ""}; 
                var model = JsonConvert.DeserializeAnonymousType(HttpContext.Current.Request.Form["model"], modelDef);

                //Criando o path do diretório
                string root =HttpContext.Current.Server.MapPath("");
                root += string.Format(@"\assets\denominacao\{0}\igreja\{1}", model.denominacaoId, model.igrejaId); 
                Directory.CreateDirectory(root);


                var nomeFile = model.filename.StartsWith("ismggiapp_");
                if (nomeFile)
                {
                    var uriDeletar = string.Format(@"http://{0}/v1/assets/denominacao/{1}/igreja/{2}/{3}", Request.RequestUri.Authority, model.denominacaoId, model.igrejaId, model.filename);

                    if ((System.IO.File.Exists(root + "\\" + model.filename)))
                    {
                        System.IO.File.Delete(root + "\\" + model.filename);
                    }
                }
                
                
                var provider = new CustomMultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);


                
                
                 
                foreach (var file in result.FileData)
                {
                    string imageName = file.LocalFileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last(); 


                    
                /*        imageName = (Guid.NewGuid().ToString().Substring(0, 20).Replace("-", "") + model.email.Replace("@", "").Replace(".", ""));

                        var rnd = new Random();
                        imageName = new string(imageName.OrderBy(x => rnd.Next()).ToArray());

                        imageName = "IsMgGiapp_" + imageName + "." + file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty).Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    */
                    
                    //Deleta o arquivo                                                            
                    //finalfile = string.Format(@"http://sgiapp.com.br/assets/cliente/{0}/site/{1}/{2}", model.denominacaoId, model.igrejaId, imageName); 

                    //var uri = string.Format(@"ftp://sgiapp:alce6582@ftp.sgiapp.com.br/httpdocs/assets/cliente/{0}/site/{1}/{2}", model.denominacaoId, model.igrejaId, imageName);

                   /* if (nomeFile)
                    {
                        try
                        {
                            FtpWebRequest requestFTPDelete = (FtpWebRequest)WebRequest.Create(uriDeletar);
                            requestFTPDelete.Method = WebRequestMethods.Ftp.DeleteFile;
                            requestFTPDelete.KeepAlive = false;
                            requestFTPDelete.UsePassive = true;

                            FtpWebResponse response = (FtpWebResponse)requestFTPDelete.GetResponse();
                            response.Close();
                        }
                        catch { }
                        
                    }*/

                   /* finalfile = "Cheguei aqui"; 
                        FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(uri);
                        requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;
                        requestFTPUploader.KeepAlive = false;
                        requestFTPUploader.UsePassive = true;

                        FileInfo fileInfo = new FileInfo(file.LocalFileName);
                        FileStream fileStream = fileInfo.OpenRead();

                        int bufferLength = 2048;
                        byte[] buffer = new byte[bufferLength];

                        Stream uploadStream = requestFTPUploader.GetRequestStream();
                        int contentLength = fileStream.Read(buffer, 0, bufferLength);

                        while (contentLength != 0)
                        {
                            uploadStream.Write(buffer, 0, contentLength);
                            contentLength = fileStream.Read(buffer, 0, bufferLength);
                        }

                        uploadStream.Close();
                        fileStream.Close();

                        requestFTPUploader = null;*/

                        //finalfile = file.LocalFileName; 


                    finalfile = string.Format(@"http://{0}/v1/assets/denominacao/{1}/igreja/{2}/{3}", Request.RequestUri.Authority, model.denominacaoId, model.igrejaId, imageName);

                }

                return Request.CreateResponse(HttpStatusCode.OK, new { fileUrl = finalfile, local = finalfile });
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, new { erro = ex.StackTrace });
            }

                       
        }
    }
}
