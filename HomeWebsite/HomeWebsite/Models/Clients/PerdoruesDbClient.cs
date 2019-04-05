using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeWebsite.Models.Entities;
using System.Data.SqlClient;
using System.Data;


namespace HomeWebsite.Models.Clients
{
    public class PerdoruesDbClient
    {
       public int Insert(Perdorues perdorues)
        {
            int id = 0;
           try
           {
               using (SqlConnection con = new SqlConnection(Connection.String()))
               {
                   using (SqlCommand cmd = new SqlCommand("InsertPerdorues",con))
                   {
                       cmd.CommandType = CommandType.StoredProcedure;

                       cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = perdorues.UserName;
                       cmd.Parameters.Add("@perdouresId", SqlDbType.Int).Direction = ParameterDirection.Output;

                       con.Open();
                       cmd.ExecuteNonQuery();
                       id = Convert.ToInt32(cmd.Parameters["@perdoruesId"].Value);
                       con.Close();
                   }
               }
           }
           catch(Exception ex)
           {
               id = 0;
           }

           return id;
        }
    }
    
}