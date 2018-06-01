using Boilerplate.WebFormsUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boilerplate.WebFormsUI.Controls
{
    public partial class SortArrows : System.Web.UI.UserControl
    {
        private SortInfoModel _csi;
        [Bindable(true)]
        public SortInfoModel CurrentSortInfo
        {
            get
            {
                if (_csi == null)
                {
                    return new SortInfoModel();
                }
                return _csi;
            }
            set
            {
                _csi = value;
            }
        }

        [Bindable(true)]
        public string SortColumn { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}