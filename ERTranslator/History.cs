using System;
using System.Data.SqlClient;
using System.Windows;

namespace ERTranslator
{
    class History
    {
        public void DBInsert(string originaltext, string translatedtext)
        {
            using (SqlConnection cn = new SqlConnection("data source=1-ПК;initial catalog=Translator;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                SqlCommand cmdInsert = new SqlCommand();
                try
                {
                    cn.Open();
                    cmdInsert.Connection = cn;
                    var param1 = cmdInsert.CreateParameter();
                    param1.DbType = System.Data.DbType.String;
                    param1.SqlValue = originaltext;
                    param1.ParameterName = "Req";
                    cmdInsert.Parameters.Add(param1);
                    var param2 = cmdInsert.CreateParameter();
                    param2.DbType = System.Data.DbType.String;
                    param2.SqlValue = translatedtext;
                    param2.ParameterName = "Resp";
                    cmdInsert.Parameters.Add(param2);
                    cmdInsert.CommandText = "INSERT INTO History VALUES (@Req, @Resp);";
                    cmdInsert.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
