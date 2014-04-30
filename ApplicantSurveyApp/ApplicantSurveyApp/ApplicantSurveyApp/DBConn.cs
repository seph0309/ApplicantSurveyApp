using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBConn
{
    public class DBConn
    {
        SqlConnection conn; 

        public DataSet execSQLCommand(String SQLCmdStr)
        {
            try
            {
                SqlCommand SQLcmd = getsqlcommand(SQLCmdStr);
                SQLcmd.CommandTimeout = 0;
                return getDataSet(SQLcmd, "DataSet");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        private SqlCommand getsqlcommand(string cmdtext)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbopen1();
            cmd.CommandText = cmdtext;
            return cmd;
        }
        private SqlConnection dbopen1()
        {
            conn = new SqlConnection();
			string conConfig = System.Configuration.ConfigurationManager.ConnectionStrings["DeltekApplicantSurveyConnectionString"].ConnectionString;
            conn.ConnectionString = conConfig;

            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conn;
        }
        private DataSet getDataSet(SqlCommand sqlcmd, String tblname)
        {
            SqlDataAdapter sqlda = getDataAdapter(sqlcmd, conn);
            if (sqlda == null) return null;
            conn.Close();
            return getDataSet(sqlda, tblname, true);
        }
        private DataSet getDataSet(SqlDataAdapter adp, string tblname, bool exec)
        {
            DataSet ds = new DataSet();
            adp.Fill(ds, tblname);
            return ds;
        }
        private SqlDataAdapter getDataAdapter(SqlCommand sqlcmd, SqlConnection conn)
        {
            try
            {
                sqlcmd.Connection = dbopen1();
                return new SqlDataAdapter(sqlcmd);
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                sqlcmd.Connection.Close();
                conn.Close();
            } 
        }
    }
}
