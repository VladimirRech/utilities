using System.Collections.Generic;
using System.Linq;

namespace dynamic.core
{
    public class MockData
    {
        public static List<dynamic> GetList()
        {
            return new List<dynamic>(new[]
                {  new {Id = 1, Name = "Item 1"},
                   new {Id = 2, Name = "Item 2"},
                   new {Id = 3, Name = "Item 3"}
            });
        }

        public static object GetElementById(List<dynamic> lst, int id)
        {
            while (lst != null && lst.Count > 0)
                return lst.Where(obj => obj.Id == id).FirstOrDefault();

            return null;
        }
    }
}
