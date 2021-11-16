using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayWebChat.DataAccess;

namespace HolidayWebChat.DataAccess
{
    public interface ILocationRepository
    {
        public IEnumerable<Location> GetAll();
        public IEnumerable<Location> GetLocationByContinent(string continent);
    }
}
