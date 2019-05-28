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
            string str = string.Format(@"Data Source=DESKTOP-1Q2TUU2\LEMOSDATABASE;Initial Catalog=DemoDatabase;Integrated Security=True");
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
