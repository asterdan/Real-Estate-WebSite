using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using HomeWebsite.Models.Entities;

namespace HomeWebsite.Models.Clients
{
    public class ShtetDbClient
    {

        public List<Shtet> GetCountries()
        {
            List<Shtet> list = new List<Shtet>();

            using(SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM Shteti",con))
                {
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                Shtet newShtet = new Shtet(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]));
                                list.Add(newShtet);
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