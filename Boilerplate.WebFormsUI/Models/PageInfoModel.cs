using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boilerplate.WebFormsUI.Models
{
    public class PageInfoModel
    {
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages
        {
            get
            {
                return (TotalRecords + RecordsPerPage - 1) / RecordsPerPage;
            }
        }

        public PageInfoModel()
        {
            CurrentPage = 1;
            RecordsPerPage = 5;
            TotalRecords = 0;
        }
    }
}