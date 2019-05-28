using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WlanTestSystem.Infra.Data.Contexto;

namespace WlanTestSystem.UI.WlanTestSystem.Domain
{
    public class Domain:ConnectionString
    {
        public void EditarStatus()
        {
            try
            {
                OpenConexao();
                string str = string.Format(@"UPDATE WlanTesteVerification SET StatusWlan = 1 WHERE StatusWlan = 0 ");
                using (cmd = new System.Data.SqlClient.SqlCommand(str, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConexao();
            }
           
        }
    }
}