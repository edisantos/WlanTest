using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WlanTestSystem.Infra.Data.Contexto
{
    public class ConnectionString
    {
        private SqlConnection con;

        
        public SqlConnection Conexao()
        {
            string str = string.Format(@"Data Source=DESKTOP-1Q2TUU2\LEMOSDATABASE;Initial Catalog=DemoDatabase;Integrated Security=True");
            con = new SqlConnection();
            return con;
        }


    }
}
