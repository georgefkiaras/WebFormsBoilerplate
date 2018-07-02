using Boilerplate.Data.Models.Repositories;
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
    public partial class Files : BasePage
    {
        private string fileRoot
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/App_Data/Files");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var filesRepo = new FilesRepo(fileRoot);
            var files = filesRepo.GetAllFiles();
            filesRepeater.DataSource = files;
            filesRepeater.DataBind();
        }

        public void FileUploadClick(object sender, EventArgs e)
        {
            var fileName = fileUpload.PostedFile.FileName;
            if(fileUpload.PostedFile == null || string.IsNullOrEmpty(fileUpload.PostedFile.FileName))
            {
                throw new ValidationException("A file is required.");
            }
            var savePath = Path.Combine(fileRoot, fileName);
            FileInfo saveInfo = new FileInfo(savePath);
            if (saveInfo.Exists)
            {
                throw new ValidationException("File Exists.");
            }
            fileUpload.PostedFile.SaveAs(savePath);
            BindData();
        }
    }
}