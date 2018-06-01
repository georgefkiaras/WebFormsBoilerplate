using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boilerplate.WebFormsUI.Models
{
    public class SortInfoModel
    {
        public string SortColumn { get; set; }
        public bool descending { get; set; }

        public SortInfoModel()
        {
            SortColumn = string.Empty;
            descending = false;
        }
    }
}