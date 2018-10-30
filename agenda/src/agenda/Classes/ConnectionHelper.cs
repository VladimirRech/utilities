using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agenda.Classes
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            Configuration.GetConnectionString("Schedules");
        }
    }
}
