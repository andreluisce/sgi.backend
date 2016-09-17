using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace sgi.api.Helpers
{
   public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
{
	public CustomMultipartFormDataStreamProvider(string path) : base(path)
	{}

       
        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {

            var modelDef = new { igrejaId = 0, denominacaoId = 0, filename = "", email = "" };
            var model = JsonConvert.DeserializeAnonymousType(HttpContext.Current.Request.Form["model"], modelDef);


            string imageName = "";


            imageName = (Guid.NewGuid().ToString().Substring(0, 20).Replace("-", "") + model.email.Replace("@", "").Replace(".", ""));

            var rnd = new Random();
            imageName = new string(imageName.OrderBy(x => rnd.Next()).ToArray());

            imageName = "IsMgGiapp_" + imageName + "." + headers.ContentDisposition.FileName.Replace("\"", string.Empty).Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1];

            return imageName.ToLower(); 

           //var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
           //return name.Replace("\"", string.Empty);
                        }
}

public class FileDesc
{
	public string Name { get; set; }
	public string Path { get; set; }
	public long Size { get; set; }
 
	public FileDesc(string n, string p, long s)
	{
            Name = n;
            Path = p;
            Size = s;
	}
}
}