using System.Data.SqlClient;

namespace WlanTestSystem.Infra.Data.Contexto
{
    public class ConnectionString
    {
        protected SqlConnection con;
        protected SqlDataAdapter Adp;
        protected SqlDataReader Dr;
        protected SqlCommand cmd;
        public SqlConnection OpenConexao()
        {
            string str = string.Format(@"add here your connection string");
            con = new SqlConnection(str);
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection CloseConexao()
        {
           ;
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }

    }
}
