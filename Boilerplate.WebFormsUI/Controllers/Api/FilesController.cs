using Boilerplate.Data.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Boilerplate.WebFormsUI.Controllers.Api
{
    public class FilesController : ApiController
    {
        private string fileRoot
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/UserFiles");
            }
        }

        /// <summary>
        /// This will not work, strictly speaking, because filenames are difficult to directly put in a route.
        /// Instead, this is an example of how an ID could potentially used to retrieve a file from a non-public
        /// directory and/or when authentication and other restrictions are needed when accessing files.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/File/{fileName}")]
        public HttpResponseMessage GetFile(string fileName)
        {
            var filePath = Path.Combine(fileRoot, fileName);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            return response;

        }

        //https://forums.asp.net/t/2104884.aspx?Uploading+a+file+using+webapi+C+
        [HttpPost]
        [Route("api/File")]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["FileUploadHolder"];

                if (httpPostedFile != null)
                {
                    var filesRepo = new FilesRepo(HttpContext.Current.Server.MapPath("~/UserFiles"));
                    filesRepo.UploadFile(httpPostedFile);
                }
                else
                {
                    throw new ValidationException("No file provided.");
                }
            }
        }
    }
}
