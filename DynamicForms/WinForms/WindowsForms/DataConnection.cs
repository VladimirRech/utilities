using System.Data;
using System.Data.SqlClient;

namespace WindowsForms
{
    public class DataConnection
    {
        public static DataTable GetDataTable(string connectionString, string sql)
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var da = new SqlDataAdapter(sql, con))
                {
                    con.Open();
                    var dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
        }
    }
}
