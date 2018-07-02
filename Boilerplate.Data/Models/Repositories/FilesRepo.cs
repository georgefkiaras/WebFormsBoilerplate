using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Boilerplate.Data.Models.Repositories
{
    public class FilesRepo
    {
        private string _filesRootPath { get; set; }

        private DirectoryInfo _fr;
        private DirectoryInfo _filesRootDirectoryInfo
        {
            get
            {
                if(_fr == null)
                {
                    _fr = new DirectoryInfo(_filesRootPath);
                    if (!_fr.Exists)
                    {
                        _fr.Create();
                    }
                }
                return _fr;
            }
        }

        public FilesRepo(string filesRootPath)
        {
            _filesRootPath = filesRootPath;
        }

        public List<FileInfo> GetAllFiles()
        {
            return _filesRootDirectoryInfo.GetFiles().ToList();
        }

        public void UploadFile(HttpPostedFile postedFile)
        {
            var savePath = Path.Combine(_filesRootPath, postedFile.FileName);
            FileInfo fileInfo = new FileInfo(savePath);
            if (fileInfo.Exists)
            {
                throw new ValidationException("File Exists");
            }
            postedFile.SaveAs(savePath);
        }
    }
}
