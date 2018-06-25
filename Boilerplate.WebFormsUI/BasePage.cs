using Boilerplate.Data.Models.Repositories;
using Boilerplate.WebFormsUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boilerplate.WebFormsUI
{
    public class BasePage : Page
    {
        /// <summary>
        /// Used in sorting/filtering
        /// </summary>
        public delegate void PageDataBinder();
        public PageDataBinder DataBinder { get; set; }
        protected string PageKey
        {
            get
            {
                return Request.Url.AbsoluteUri.ToString();
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            var exc = Server.GetLastError();
            if (exc is ValidationException)
            {
                Server.Transfer("ValidationError.aspx", true);
            }
        }

        #region repos
        private StopsRepo _s;
        protected StopsRepo _stopsRepo
        {
            get
            {
                if(_s != null)
                {
                    return _s;
                }
                var appDataPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
                var stopsCSV_Path = Path.Combine(appDataPath, "Stops.csv");
                _s = new StopsRepo(stopsCSV_Path);
                return _s;
            }
        }
        #endregion

        #region sorting

        /// <summary>
        /// Return a sort column model showing what column we are sorting by, if any, and if it is descending
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        private SortInfoModel GetSortColumnForPage()
        {
            var sortColumnKey = PageKey + "_sortColumn";
            var sortDirectionKey = PageKey + "_desc";
            var sortColumn = "";
            if (ViewState[sortColumnKey] != null)
            {
                sortColumn = ViewState[sortColumnKey].ToString();
            }
            var descending = false;
            if (ViewState[sortDirectionKey] != null)
            {
                descending = bool.Parse(ViewState[sortDirectionKey].ToString());
            }
            return new SortInfoModel
            {
                SortColumn = sortColumn,
                descending = descending
            };
        }



        //this exposes the current sort information to the view
        public SortInfoModel CurrentSortInfo
        {
            get
            {
                return GetSortColumnForPage();
            }
        }

        protected void SetSortColumnForPage(string sortColumn, bool descending)
        {
            var sortColumnKey = PageKey + "_sortColumn";
            var sortDirectionKey = PageKey + "_desc";
            ViewState[sortColumnKey] = sortColumn;
            ViewState[sortDirectionKey] = descending.ToString();
        }

        protected void sortColumn_click(object sender, EventArgs e)
        {
            var linkButton = ((LinkButton)sender);
            var commandArgument = linkButton.CommandArgument.ToString(); //the column to sort by
            var currentSortInfo = GetSortColumnForPage();
            if (currentSortInfo.SortColumn == commandArgument)
            {
                //in this case, just inverse the sort order
                SetSortColumnForPage(commandArgument, !currentSortInfo.descending);
            }
            else
            {
                SetSortColumnForPage(commandArgument, true);
            }
            DataBinder?.Invoke();
        }
        #endregion

        #region pagination
        private PageInfoModel GetPageInfoForPage()
        {
            var currentPageString = PageKey + "_currentPage";
            var recordsPerPageString = PageKey + "_recordsPerPage";
            var totalRecordsString = PageKey + "_totalRecords";
            var pageInfoModel = new PageInfoModel(); //default: currentPage: 1, RecordsPerPage: 50, TotalRecords: 0
            if (ViewState[currentPageString] != null)
            {
                pageInfoModel.CurrentPage = int.Parse(ViewState[currentPageString].ToString());
            }
            if (ViewState[recordsPerPageString] != null)
            {
                pageInfoModel.RecordsPerPage = int.Parse(ViewState[recordsPerPageString].ToString());
            }
            if (ViewState[totalRecordsString] != null)
            {
                pageInfoModel.TotalRecords = int.Parse(ViewState[totalRecordsString].ToString());
            }
            return pageInfoModel;
        }

        public PageInfoModel CurrentPageInfo
        {
            get
            {
                return GetPageInfoForPage();
            }
        }

        public void SetPagingInfo(int currentPage, int recordsPerPage)
        {
            var currentPageString = PageKey + "_currentPage";
            var recordsPerPageString = PageKey + "_recordsPerPage";
            ViewState[currentPageString] = currentPage.ToString();
            ViewState[recordsPerPageString] = recordsPerPage.ToString();
        }

        public void SetPagingData<T>(IEnumerable<T> baseCollection)
        {
            var totalRecordsString = PageKey + "_totalRecords";
            ViewState[totalRecordsString] = baseCollection.Count();
        }

        public IEnumerable<T> GetPagedData<T>(IEnumerable<T> query)
        {
            var pageInfo = GetPageInfoForPage();
            var q = query.Skip((pageInfo.CurrentPage - 1) * pageInfo.RecordsPerPage).Take(pageInfo.RecordsPerPage);
            return q;
        }

        protected void NextPage_Click(object sender, EventArgs e)
        {
            SetPagingInfo(++CurrentPageInfo.CurrentPage, CurrentPageInfo.RecordsPerPage);
            DataBinder();
        }

        protected void PrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageInfo.CurrentPage > 1)
            {
                SetPagingInfo(--CurrentPageInfo.CurrentPage, CurrentPageInfo.RecordsPerPage);
            }
            DataBinder();
        }

        protected void PageNum_Click(object sender, EventArgs e)
        {
            var commandArgument = ((LinkButton)sender).CommandArgument;
            var pageNumber = int.Parse(commandArgument);
            SetPagingInfo(pageNumber, CurrentPageInfo.RecordsPerPage);
            DataBinder();
        }

        protected void RecordsNum_Click(object sender, EventArgs e)
        {
            var commandArgument = ((LinkButton)sender).CommandArgument;
            var recordsPerPage = int.Parse(commandArgument);
            SetPagingInfo(1, recordsPerPage);
            DataBinder();
        }

        public string FormatPageNumberBtn(object o)
        {
            int buttonPageNumber = (int)o;
            var openTag = "";
            if (buttonPageNumber == CurrentPageInfo.CurrentPage)
            {
                openTag = "<span class='btn btn-sm btn-default'>";
            }
            else
            {
                openTag = "<span class='btn btn-sm btn-success'>";
            }
            return openTag + buttonPageNumber.ToString() + "</span>";
        }

        public string FormatRecordsPerPage(object o)
        {
            int recordsPerPage = (int)o;
            var openTag = "";
            if (recordsPerPage == CurrentPageInfo.RecordsPerPage)
            {
                openTag = "<span class='btn btn-sm btn-default'>";
            }
            else
            {
                openTag = "<span class='btn btn-sm btn-warning'>";
            }
            return openTag + recordsPerPage.ToString() + "</span>";
        }

        protected void BindPaginationControls(Repeater pageNumbersRepeater, Repeater recordsPerPageRepeater)
        {
            BindPageNumbersRepeater(pageNumbersRepeater);
            BindRecordsPerPageRepeater(recordsPerPageRepeater);
        }

        protected void BindPageNumbersRepeater(Repeater pageNumbersRepeater)
        {
            var pageList = Enumerable.Range(1, CurrentPageInfo.TotalPages).ToList();
            pageNumbersRepeater.DataSource = pageList;
            pageNumbersRepeater.DataBind();
        }

        protected void BindRecordsPerPageRepeater(Repeater recordsPerPageRepeater)
        {
            var recordsPerPageList = new List<int> { 5, 10, 50, 100, 200 };
            recordsPerPageRepeater.DataSource = recordsPerPageList;
            recordsPerPageRepeater.DataBind();
        }

        #endregion
    }
}