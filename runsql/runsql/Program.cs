using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace runsql
{
    class Program
    {
        static string[] _help = new string[] { "/?", "-h", "-help" };
        static string[] _validOperations = new string[] { "-exec", "-query", "-qryfile" };
        static string _usage = "Uso\r\n\t" +
                               "runsql -exec file.sql server database userid password\r\n\r\n\t" +
                               "runsql -query file.sql server database userid password delimiter\r\n\r\n\t" +
                               "runsql -qryfile file.sql server database userid password delimiter\r\n\r\n\t";
        static string _openningTitle = "Abrindo conexão";
        static string _preparingTitle = "Preparando";
        static string _openningFileTitle = "Abrindo arquivo";
        static string _readingRowTitle = "Lendo linha ";
        static string _executingTitle = "Executando linha: {0:000000}";

        static void Main(string[] args)
        {
            if (args.Length == 0 || _help.Contains(args[0]) || !_validOperations.Contains(args[0]) || (args[0] == "-query" &&  args.Length != 7) ||
                (args[0] == "-query" && args.Length < 6))
            {
                Console.WriteLine(_usage);
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

            switch (args[0].ToLower())
            {
                case "-exec":
                    exec(fileName, connString, counter);
                    Console.WriteLine("Concluído");
                    break;
                case "-query":
                    query(fileName, connString, counter, separator);
                    break;
                case "-qryfile":
                    qryfile(fileName, connString, counter, separator);
                    break;
                default:
                    break;
            }
        }

        private static void query(string fileName, string connString, int counter, string separator)
        {
            Console.Title = _preparingTitle;
            using (var con = new SqlConnection(connString))
            {
                Console.Title = _openningTitle;
                con.Open();

                Console.Title = _openningFileTitle;

                using (var f = System.IO.File.OpenText(fileName))
                {
                    while (f.Peek() > -1)
                    {
                        Console.Title = _readingRowTitle + counter.ToString();
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
            Console.Title = _openningTitle;

            using (var con = new SqlConnection(connString))
            {
                con.Open();

                Console.Title = _openningFileTitle;

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

        /// <summary>
        /// Executa o arquivo inteiro como uma única consulta
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="connString"></param>
        /// <param name="counter"></param>
        /// <param name="separator"></param>
        private static void qryfile(string fileName, string connString, int counter, string separator)
        {
            Console.Title = _preparingTitle;
            using (var con = new SqlConnection(connString))
            {
                Console.Title = _openningTitle;
                con.Open();
                Console.Title = _openningFileTitle;
                string fileContent = System.IO.File.ReadAllText(fileName);
                Console.Title = _readingRowTitle + counter.ToString();

                using (SqlDataAdapter da = new SqlDataAdapter(fileContent, con))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Console.Title = String.Format(_readingRowTitle, i + 1);

                            if (i == 0)
                            {
                                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                                    Console.Write("{0}{1}", dt.Columns[colIndex].ColumnName, separator);


                                Console.Write(Environment.NewLine);
                            }

                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                Console.Write("{0}{1}", dt.Rows[i][j], separator);
                            }

                            Console.Write(Environment.NewLine);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    counter++;
                }

                con.Close();
            }
        }

    }
}
