using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem.Core
{
    public class WorkContext
    {
        private readonly ConnectString connectString;

        public WorkContext(ConnectString connectString)
        {
            this.connectString = connectString;
        }

        public DataTable GetRecordsInATable(string columns, string table, string condition, Dictionary<string, object> parameters)
        {
            var dt = new DataTable();

            var url = ConfigurationManager.ConnectionStrings[connectString.url].ConnectionString;

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Kiểm tra lại đường dẫn kết nối");
                return null;
            }

            var conn = new SqlConnection(url);

            var query = string.Empty;

            if (string.IsNullOrEmpty(columns))
            {
                columns = "*";
            }

            if (string.IsNullOrEmpty(table))
            {
                return null;
            }

            query = string.IsNullOrEmpty(condition) ?
                  string.Format("Select {0} from {1}", columns, table)
                : string.Format("Select {0} from {1} where {2}", columns, table, condition);

            try
            {
                conn.Open();

                var cmd = new SqlCommand(query, conn);

                if (parameters != null && !string.IsNullOrEmpty(condition))
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }
                }
                var da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool ExecuteProcedureParams(string procedureName, Dictionary<string, object> parameters)
        {
            var url = ConfigurationManager.ConnectionStrings[connectString.url].ConnectionString;

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Kiểm tra lại đường dẫn kết nối");
                return false;
            }

            var conn = new SqlConnection(url);

            if (string.IsNullOrEmpty(procedureName))
            {
                return false;
            }

            try
            {
                conn.Open();

                var cmd = new SqlCommand(procedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }
                }
                var stt = cmd.ExecuteNonQuery();

                if (stt > 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
