using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace runsql
{
    class Program
    {
        static string[] _help = new string[] { "/?", "-h", "-help" };
        static string[] _validOperations = new string[] { "-exec", "-query" };
        static void Main(string[] args)
        {
            /* Uso 
             * 
             * runsql -exec file.sql server database userid password
             * 
             * runsql -query file.sql server database userid password delimiter
             * 
             * 
             */
            if (args.Length == 0 || _help.Contains(args[0]) || !_validOperations.Contains(args[0]) || (args[0] == "-query" &&  args.Length != 7) ||
                (args[0] == "-query" && args.Length < 6))
            {
                Console.WriteLine(@"Uso 

    runsql -exec file.sql server database userid password

    runsql -query file.sql server database userid password delimiter");
                return;
            }

            string fileName = args[1];
            string serverName = args[2];
            string database = args[3];
            string user = args[4];
            string pass = args[5];
            string separator = args.Length == 7 ? args[6] : "";
            string connString = String.Format("Data source={0}; Initial catalog={1};" +
                "User id={2}; password={3}", serverName, database, user, pass);
            int counter = 1;

            if (args[0].ToLower() == "-exec")
                exec(fileName, connString, counter);
            else
                query(fileName, connString, counter, separator);

            Console.WriteLine("Concluído");
        }

        private static void query(string fileName, string connString, int counter, string separator)
        {
            Console.Title = "Preparando conexão";
            using (var con = new SqlConnection(connString))
            {
                Console.Title = "Abrindo conexão";
                con.Open();

                Console.Title = "Abrindo arquivo";

                using (var f = System.IO.File.OpenText(fileName))
                {
                    while (f.Peek() > -1)
                    {
                        Console.Title = "Lendo linha " + counter.ToString();
                        using (SqlDataAdapter da = new SqlDataAdapter(f.ReadLine(), con))
                        {
                            try
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dt.Columns.Count; j++)
                                    {
                                        Console.Write("{0}{1}", dt.Rows[i][j], separator);
                                    }

                                    Console.Write(System.Environment.NewLine);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            counter++;
                        }
                    }
                }

                con.Close();
            }
        }

        private static void exec(string fileName, string connString, int counter)
        {
            Console.Title = "Abrindo conexão.";

            using (var con = new SqlConnection(connString))
            {
                con.Open();

                Console.Title = "Abrindo arquivo de texto.";

                using (var f = System.IO.File.OpenText(fileName))
                {
                    while (f.Peek() > -1)
                    {
                        string errorMessage = null;

                        Console.Title = string.Format("Executando linha: {0:000000}", counter);

                        using (SqlCommand cmd = new SqlCommand(f.ReadLine(), con))
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
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
