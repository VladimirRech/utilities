﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms;

namespace ConsoleApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = GetCorrectJson();
            string error = "";
            var df = DynamicDialog.GetFromJson(json, out error);
            df.ShowDialog();
        }

        static string GetCorrectJson()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("\"name\":\"form1\",");
            sb.AppendLine("\"text\":\"Primeiro formulário\",");
            sb.AppendLine("\"type\":\"OK\",");
            sb.AppendLine("\"controls\":[");
            sb.AppendLine("  {");
            sb.AppendLine("    \"name\":\"txtText1\",");
            sb.AppendLine("    \"type\":\"TextBox\",");
            sb.AppendLine("    \"key\":\"text1\",");
            sb.AppendLine("    \"label\":\"Campo texto\",");
            sb.AppendLine("    \"initialValue\":\"Some text\"");
            sb.AppendLine("  },");
            sb.AppendLine("  {");
            sb.AppendLine("    \"name\":\"cboName\",");
            sb.AppendLine("    \"type\":\"ComboBox\",");
            sb.AppendLine("    \"key\":\"name1\",");
            sb.AppendLine("    \"label\":\"Campo múltipla escolha\",");
            sb.AppendLine("    \"initialValue\":\"1\",");
            sb.AppendLine("    \"bindingSource\": {");
            //sb.AppendLine("        \"connection\":\"Data source=localhost\\sqlexpress2014; Initial catalog=adventureworks2012; Integrated security=true;\",");
            sb.AppendFormat("      \"connection\":\"Data source={0}; Initial catalog=adventureworks2012; Integrated security=true;\", ", @"localhost\\sqlexpress2014");
            sb.AppendLine("        \"sql\":\"select id, name from programmers order by name\",");
            sb.AppendLine("        \"keyValue\":\"id\",");
            sb.AppendLine("        \"displayValue\":\"name\"");
            sb.AppendLine("  }}]");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
