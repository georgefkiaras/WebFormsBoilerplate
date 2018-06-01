using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate.Data.Models.Dto;

namespace Boilerplate.Data.Models.Repositories
{
    public class StopsRepo
    {
        private string _stopsCSV_Path;

        public StopsRepo(string stopsCSV_Path)
        {
            _stopsCSV_Path = stopsCSV_Path;
        }

        private List<StopDto> _s;
        private List<StopDto> _stops
        {
            get
            {
                if(_s != null)
                {
                    return _s;
                }
                _s = new List<StopDto>();
                using (var reader = new StreamReader(_stopsCSV_Path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        //Id,Code,Name,Description,Latitude,Longitude,Zone,Url,LocationType,ParentStation
                        var newStopDto = new StopDto
                        {
                            Id = values[0],
                            Code = values[1],
                            Name = values[2],
                            Description = values[3],
                            Latitude = values[4],
                            Longitude = values[5],
                            Zone = values[6],
                            Url = values[7],
                            LocationType = values[8],
                            ParentStation = values[9]
                        };
                        _s.Add(newStopDto);
                    }
                }
                return _s;
            }
        }


        public List<StopDto> GetAllStops()
        {
            return _stops.Where(s => string.IsNullOrEmpty(s.ParentStation)).ToList();
        }

        public StopDto GetStop(string stopId)
        {
            return _stops.FirstOrDefault(s => s.Id == stopId);
        }

    }
}
