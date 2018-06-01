using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Boilerplate.Data.Models.Dto;
using Boilerplate.Data.Models.Repositories;

namespace Boilerplate.WebFormsUI
{
    public partial class Stops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var appDataPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            var stopsCSV_Path = Path.Combine(appDataPath, "Stops.csv");
            var repo = new StopsRepo(stopsCSV_Path);
            var results = repo.GetAllStops();
        }
    }
}