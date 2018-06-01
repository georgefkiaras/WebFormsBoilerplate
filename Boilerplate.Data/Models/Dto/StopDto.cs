using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Data.Models.Dto
{
    public class StopDto
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Zone { get; set; }
        public string Url { get; set; }
        public string LocationType { get; set; }
        public string ParentStation { get; set; }
    }
}
