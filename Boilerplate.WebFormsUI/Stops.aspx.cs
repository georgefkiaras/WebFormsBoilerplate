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
        public string LastMessage = "";
        public DateTime LastMessageDate = DateTime.Now;
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
            LastMessage = MessageRepo.Message;
            LastMessageDate = MessageRepo.LastDateTime;
            var stops = _stopsRepo.GetAllStops();

            if(idFilter.Text != string.Empty)
            {
                stops = stops.AsQueryable().Where(s => s.Id.ToLower().Contains(idFilter.Text.ToLower())).ToList();
            }
            if (nameFilter.Text != string.Empty)
            {
                stops = stops.AsQueryable().Where(s => s.Name.ToLower().Contains(nameFilter.Text.ToLower())).ToList();
            }


            if (CurrentSortInfo.SortColumn != string.Empty)
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


        #region filters
        protected void Filter_Change(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Filter_Clear(object sender, EventArgs e)
        {
            ClearFilters();
            BindData();
        }

        private void ClearFilters()
        {
            idFilter.Text = "";
            nameFilter.Text = "";
        }
        #endregion

        #region formatters

        public string FormatDetailButton(object o)
        {
            var stop = (StopDto)o;
            var returnString = string.Format("<span class='btn btn-warning btn-sm stationViewButton' data-station-id='{0}'>View &raquo;</span>", stop.Id);
            return returnString;
        }

        #endregion
    }
}