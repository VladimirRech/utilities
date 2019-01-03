using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsForms;

namespace DynamicForms.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Test_valid_desserialization()
        {
            string error = string.Empty;
            DynamicDialog dynamicDialog = DynamicDialog.GetFromJson(null, out error);
            Assert.IsNull(dynamicDialog);
            Assert.IsNotNull(error);

            // Sending incorrect Json
            dynamicDialog = DynamicDialog.GetFromJson(GetIncorrectJson(), out error);
            Assert.IsNull(dynamicDialog);
            Assert.IsNotNull(error);

            // Sending correct json
            dynamicDialog = DynamicDialog.GetFromJson(GetCorrectJson(), out error);
            Assert.IsNotNull(dynamicDialog);
            Assert.IsTrue(string.IsNullOrEmpty(error));
        }

        public static string GetIncorrectJson()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"name\":\"json serializer\",");
            sb.AppendLine("  \"date\":\"2018-02-02\"");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static string GetCorrectJson()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("\"name\":\"form1\",");
            sb.AppendLine("\"text\":\"Primeiro formulário\",");
            sb.AppendLine("\"type\":\"OK|YesNo\",");
            sb.AppendLine("\"controls\":[");
            sb.AppendLine("{");
            sb.AppendLine("\"name\":\"txtText1\",");
            sb.AppendLine("\"type\":\"TextBox\",");
            sb.AppendLine("\"key\":\"text1\",");
            sb.AppendLine("\"label\":\"Campo texto\",");
            sb.AppendLine("\"initialValue\":\"Some text\"");
            sb.AppendLine("},");
            sb.AppendLine("{");
            sb.AppendLine("\"name\":\"cboName\",");
            sb.AppendLine("\"type\":\"ComboBox\",");
            sb.AppendLine("\"key\":\"name1\",");
            sb.AppendLine("\"label\":\"Campo múltipla escolha\",");
            sb.AppendLine("\"initialValue\":\"1\",");
            sb.AppendLine("\"bindingSource\": {");
            sb.AppendLine("    \"connection\":\"Data source=local; Initial catalog=databasename; Integrated security=true;\",");
            sb.AppendLine("    \"sql\":\"SELECT ID, NAME FROM USERS ORDER BY NAME\",");
            sb.AppendLine("    \"keyValue\":\"id\",");
            sb.AppendLine("    \"displayValue\":\"name\"");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
