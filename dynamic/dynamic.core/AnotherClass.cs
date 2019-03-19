using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic.core
{
    public class AnotherClass
    {
        public static object QueryList(List<dynamic> lst, int query)
        {
            return lst.Where(obj => obj.Id == query).FirstOrDefault();
        }
    }
}
