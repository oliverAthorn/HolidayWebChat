using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HolidayWebChat.DataAccess;

namespace HolidayWebChat.DataAccess
{
    public class LocationRepository : ILocationRepository
    {
        private readonly string _connectionString;

        public LocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Location> GetAll()
        {
            const string query = "SELECT [Id], [Continent], [Country], [City] FROM [Location]";
            using var conn = new SqlConnection(_connectionString);
            return conn.Query<Location>(query).AsList();
        }

        public IEnumerable<Location> GetLocationByContinent(string continent)
        { 
            string query =
                $"SELECT [Continent], [Country], [City] FROM [Location] WHERE [Continent] = '{continent}'";

            using var conn = new SqlConnection(_connectionString);
            return conn.Query<Location>(query).AsList();
        }
    }
}
