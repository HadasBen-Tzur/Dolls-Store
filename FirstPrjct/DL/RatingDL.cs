using Ent;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL : IRatingDL
    {
        public RatingDL()
        {

        }
        public void insertRating(Rating r)
        {
            string query1 = "INSERT INTO Rating(HOST,METHOD,PATH,REFERER,USER_AGENT,Record_Date)" +
                "VALUES(@HOST,@METHOD,@PATH,@REFERER,@USER_AGENT,@Record_Date)";

            using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-OON8DCLU;Initial Catalog=AmericanDolll;Integrated Security=True"))
            using (SqlCommand cmd1 = new SqlCommand(query1, cn1))
            {
                cmd1.Parameters.Add("@HOST", SqlDbType.VarChar, 50).Value = r.Host;
                cmd1.Parameters.Add("@METHOD", SqlDbType.VarChar, 10).Value = r.Method;
                cmd1.Parameters.Add("@PATH", SqlDbType.VarChar, 50).Value = r.Path;
                cmd1.Parameters.Add("@REFERER", SqlDbType.VarChar, 50).Value = r.Referer;
                cmd1.Parameters.Add("@USER_AGENT", SqlDbType.VarChar, 50).Value = r.UserAgent;
                cmd1.Parameters.Add("@Record_Date", SqlDbType.DateTime, 50).Value = r.RecordDate;

                cn1.Open();
                int row1 = cmd1.ExecuteNonQuery();
                cn1.Close();
            }
        }
    }
}
