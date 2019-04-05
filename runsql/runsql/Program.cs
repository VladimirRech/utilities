using System;
using System.Data.SqlClient;

namespace runsql
{
    class Program
    {
        static void Main(string[] args)
        {
            //1-arquivo
            //2-servidor
            //3-base de dados
            //4-user id
            //5-password
            if (args.Length != 5)
            {
                Console.WriteLine("Usage runsql sqlfile server database user_id password");
                return;
            }

            string fileName = args[0];
            string serverName = args[1];
            string database = args[2];
            string user = args[3];
            string pass = args[4];
            string connString = String.Format("Data source={0}; Initial catalog={1};" +
                "User id={2}; password={3}", serverName, database, user, pass);
            int counter = 1;

            using (var con = new SqlConnection(connString))
            {
                con.Open();

                using (var f = System.IO.File.OpenText(fileName))
                {
                    while (f.Peek() > -1)
                    {
                        string errorMessage = null;

                        using (SqlCommand cmd = new SqlCommand(f.ReadLine(), con))
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch(Exception ex)
                            {
                                errorMessage = ex.Message;
                            }

                            Console.WriteLine("Line {0:00000}: {1}", counter, string.IsNullOrEmpty(errorMessage) ? "OK" : errorMessage);
                            counter++;
                        }
                    }
                }

                con.Close();
            }
        }

    }
}
