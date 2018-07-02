using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
