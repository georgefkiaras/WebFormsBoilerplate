using Boilerplate.Data.Models.Dto;
using Boilerplate.Data.Models.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Boilerplate.WebFormsUI.Controllers.Api
{
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
    }
}
