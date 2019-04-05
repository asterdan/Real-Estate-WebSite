using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using HomeWebsite.Models.Entities;

namespace HomeWebsite.Models.Clients
{
    public class QytetDbClient
    {
        public List<Qytet> GetCities()
        {
            List<Qytet> list = new List<Qytet>();

            using(SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM Qyteti",con))
                {
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                Qytet qytet = new Qytet(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToInt32(reader[2]));
                                list.Add(qytet);
                            }
                        }
                    }
                    con.Close();
                }
            }

            return list;
        }
    }
}