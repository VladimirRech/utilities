using agenda.Classes;
using agenda.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace agenda.Controllers
{
    [Produces("application/json")]
    [Route("api/schedule")]
    public class ScheduleController : Controller
    {
        [HttpGet]
        public IEnumerable<Schedule> Get()
        {
            return GetLastHundreds();
        }

        /// <summary>
        /// Retorna itens pela data. Deve estar no formato 'YYYY-MM-DD': api/schedules/2018-04-15
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("{date}", Name = "GetByDate")]
        public IEnumerable<Schedule> GetByDate(string date)
        {
            if (string.IsNullOrEmpty(date)){
                return null;
            }

            DateTime dateIni;
            DateTime dateEnd;

            if (!DateTime.TryParse(date, out dateIni))
            {
                return null;
            }

            dateEnd = new DateTime(dateIni.Year, dateIni.Month, dateIni.Day, 23, 59, 59);

            return GetListByDate(dateIni, dateEnd);
        }

        // GET http://localhost:59475/api/schedule/dateandowner?date=2018-09-10&name=Abbott,%20Ima%20A.
        [HttpGet("DateAndOwner")]
        public IEnumerable<Schedule> GetByDateAndName([FromQuery]string date, [FromQuery]string name)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrEmpty(name))
            {
                return null;
            }

            DateTime dateIni;
            DateTime dateEnd;

            if (!DateTime.TryParse(date, out dateIni))
            {
                return null;
            }

            dateEnd = new DateTime(dateIni.Year, dateIni.Month, dateIni.Day, 23, 59, 59);
            string sql = "select * from users_schedules where StartDate between @StartDateIni and @StartDateEnd and [owner] = @owner";

            using (var conn = new SqlConnection(ConfigHelper.ConnectionString))
            {
                return conn.Query<Schedule>(sql, new { StartDateIni = dateIni, StartDateEnd = dateEnd, owner = name }).ToList();
            }
        }

        List<Schedule> GetLastHundreds()
        {
            string sql = "select top 100 * from users_schedules order by id desc";

            using(var conn = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var lst = conn.Query<Schedule>(sql).ToList();
                return lst;
            }
        }

        List<Schedule> GetListByDate(DateTime dateIni, DateTime dateEnd){
            string sql = "select * from users_schedules where StartDate between @StartDateIni and @StartDateEnd";

            using(var conn = new SqlConnection(ConfigHelper.ConnectionString))
            {
                return conn.Query<Schedule>(sql, new { StartDateIni = dateIni, StartDateEnd = dateEnd }).ToList();
            }
        }
    }
}