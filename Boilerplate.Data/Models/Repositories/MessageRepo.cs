using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Data.Models.Repositories
{
    public static class MessageRepo
    {
        public static string Message { get; set; }
        public static DateTime LastDateTime { get; set; }

        static MessageRepo()
        {
            Message = "";
            LastDateTime = DateTime.Now;
        }

    }
}
