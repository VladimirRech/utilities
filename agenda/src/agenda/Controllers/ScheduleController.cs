using agenda.Classes;
using agenda.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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

        List<Schedule> GetLastHundreds()
        {
            string sql = "select top 100 * from users_schedules order by id desc";

            using(var conn = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var lst = conn.Query<Schedule>(sql).ToList();
                return lst;
            }
        }
    }
}