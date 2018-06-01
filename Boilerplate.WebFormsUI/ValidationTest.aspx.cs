using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boilerplate.WebFormsUI
{
    public partial class ValidationTest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            throw new ValidationException("A validation Exception was thrown.  You can throw a 'Validation Exception' anywhere in the code and it will show up here for the user.  Use these exceptions for business rule violations or other exceptions the user needs to know.");
        }
    }
}