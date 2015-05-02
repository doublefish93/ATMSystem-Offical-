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
                  string.Format("Select {0} from [{1}]", columns, table)
                : string.Format("Select {0} from [{1}] where {2}", columns, table, condition);

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

        public DataTable GetById(string columns, string table, string id)
        {
            var dt = new DataTable();

            var url = ConfigurationManager.ConnectionStrings[connectString.url].ConnectionString;

            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            var conn = new SqlConnection(url);

            var queryGetColumnName = string.Empty;

            if (string.IsNullOrEmpty(columns))
            {
                columns = "*";
            }

            if (string.IsNullOrEmpty(table))
            {
                return null;
            }

            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            queryGetColumnName = string.Format("SELECT COLUMN_NAME FROM information_schema.columns WHERE TABLE_NAME= '{0}'", table);

            try
            {
                var cmd = new SqlCommand(queryGetColumnName, conn);

                var da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var firstColumnId = dt.Rows[0][0].ToString();

                    var query = string.Format("Select top 1 {0} from {1} where {2}={3}", columns, table, firstColumnId, id);

                    var cmdGetFirst = new SqlCommand(query, conn);

                    var daGetFirst = new SqlDataAdapter(cmdGetFirst);

                    var dtGetFirst = new DataTable();

                    daGetFirst.Fill(dtGetFirst);

                    return dtGetFirst.Rows.Count > 0 ? dtGetFirst : null;
                }
                return null;
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

        public int CountRecords(string column, bool distinct, string table, string condition, Dictionary<string, object> parameters)
        {
            var dt = new DataTable();

            var url = ConfigurationManager.ConnectionStrings[connectString.url].ConnectionString;

            if (string.IsNullOrEmpty(url))
            {
                return -1;
            }

            var conn = new SqlConnection(url);

            var query = string.Empty;

            if (string.IsNullOrEmpty(column))
            {
                column = "*";
            }

            if (distinct && !column.Equals("*"))
            {
                column = string.Format("DISTINCT {0}", column);
            }

            if (string.IsNullOrEmpty(table))
            {
                return -1;
            }

            query = string.IsNullOrEmpty(condition) ?
                  string.Format("Select Count({0}) from {1}", column, table)
                : string.Format("Select Count({0}) from {1} where {2}", column, table, condition);

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

                var result = 0;

                if (dt.Rows.Count > 0)
                {
                    int.TryParse(dt.Rows[0][0].ToString(), out result);
                    return result;
                }
                return result;

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
