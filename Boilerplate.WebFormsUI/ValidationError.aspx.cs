using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boilerplate.WebFormsUI
{
    public partial class ValidationError : System.Web.UI.Page
    {
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            if (lastError != null)
            {
                ErrorMessage = lastError.Message;
            }
            else
            {
                ErrorMessage = "There is currently no error message.";
            }

        }
    }
}