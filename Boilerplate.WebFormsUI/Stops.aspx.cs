using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Boilerplate.Data.Models.Dto;
using Boilerplate.Data.Models.Repositories;
using Boilerplate.WebFormsUI.Utilities;

namespace Boilerplate.WebFormsUI
{
    public partial class Stops : BasePage
    {
        public int StopsCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.DataBinder = BindData;
            if (!Page.IsPostBack)
            {
                SetSortColumnForPage("Id", false);
                BindData();
            }
        }

        private void BindData()
        {
            var stops = _stopsRepo.GetAllStops();

            if(CurrentSortInfo.SortColumn != string.Empty)
            {
                stops = stops.AsQueryable().OrderBy(CurrentSortInfo.SortColumn, CurrentSortInfo.descending).ToList();
            }

            StopsCount = stops.Count();
            SetPagingData(stops);
            stopsRepeater.DataSource = GetPagedData(stops);
            stopsRepeater.DataBind();
            this.DataBind();
            BindPaginationControls(pageNumbersRepeater: pageNumbersRepeater, recordsPerPageRepeater: recordsPerPageRepeater);
        }
    }
}