using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Extension
    {
        public static object GetValueFromDynamicList(this List<dynamic> lst, 
            string comparePropertyName, string valuePropertyName, 
            string compareValue)
        {
            object obj = null;
            var i = 0;
            Boolean canCompare = lst != null &&
                                 lst.Count > 0 &&
                                 !String.IsNullOrEmpty(comparePropertyName) &&
                                 !String.IsNullOrEmpty(valuePropertyName) &&
                                 !String.IsNullOrWhiteSpace(compareValue) &&
                                 lst[0].GetType() != null &&
                                 lst[0].GetType().GetProperty(comparePropertyName) != null &&
                                 lst[0].GetType().GetProperty(valuePropertyName) != null;

            while (canCompare && obj == null && i < lst.Count)
            {
                obj = lst[i].GetType().GetProperty(comparePropertyName).GetValue(lst[i], null).ToString() == compareValue ?
                        lst[i].GetType().GetProperty(valuePropertyName).GetValue(lst[i], null) : 
                        null;
                i++;
            }

            return obj;
        }
    }
}
