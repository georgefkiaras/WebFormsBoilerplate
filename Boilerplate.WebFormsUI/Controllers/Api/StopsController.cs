using Boilerplate.Data.Models.Dto;
using Boilerplate.Data.Models.Repositories;
using Boilerplate.WebFormsUI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Boilerplate.WebFormsUI.Controllers.Api
{
    [ValidationExceptionFilterAttribute]
    public class StopsController : ApiController
    {
        private StopsRepo _s;
        protected StopsRepo _stopsRepo
        {
            get
            {
                if (_s != null)
                {
                    return _s;
                }
                var appDataPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
                var stopsCSV_Path = Path.Combine(appDataPath, "Stops.csv");
                _s = new StopsRepo(stopsCSV_Path);
                return _s;
            }
        }

        [HttpGet]
        [Route("api/Hello")]
        public string Hello()
        {
            return "Hello from API controller.";
        }

        [HttpGet]
        [Route("api/Stops")]
        public List<StopDto> Stops()
        {
            return _stopsRepo.GetAllStops();
        }

        [HttpGet]
        [Route("api/Stop/{stopId}")]
        public StopDto Stop(string stopId)
        {
            return _stopsRepo.GetStop(stopId);
        }

        [HttpPost]
        [Route("api/Message")]
        public string SetMessage(MessageUpdateDto messageDto)
        {
            MessageRepo.Message = messageDto.Message;
            if(MessageRepo.Message == null)
            {
                MessageRepo.Message = "";
            }
            MessageRepo.LastDateTime = DateTime.Now;
            return "Message update success";
        }

        [HttpPost]
        [Route("api/ValidationError")]
        public string ValidationError(MessageUpdateDto messageDto)
        {
            throw new ValidationException("There was a validation exception thrown. Something would be wrong with the input in this case.");
            return "You will never see me.";
        }

        [HttpPost]
        [Route("api/Exception")]
        public string ExceptionError(MessageUpdateDto messageDto)
        {
            throw new NotImplementedException();
            return "You will never see me.";
        }
    }
}
