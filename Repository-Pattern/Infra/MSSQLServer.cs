using Repository_Pattern.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_Pattern.Infra
{
    public class MSSQLServer : IDB
    {
        SqlConnection con;
        string strcon;

        public MSSQLServer(IInfraConfiguration dbConfig)
        {
            strcon = dbConfig.ConnectionString;
        }

        public void Dispose()
        {
            con.Close();
            con.Dispose();
        }
        public IDbConnection GetConnection()
        {
            if (con == null || con.State != ConnectionState.Open)
                con = new SqlConnection(strcon);

            con.Open();
            return con;
        }
    }
}
