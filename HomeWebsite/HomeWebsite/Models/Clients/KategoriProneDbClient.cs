using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using HomeWebsite.Models.Entities;

namespace HomeWebsite.Models.Clients
{
    public class KategoriProneDbClient
    {
        public List<KategoriProne> GetCategories()
        {
            List<KategoriProne> list = new List<KategoriProne>();

            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KategoriProne", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                KategoriProne kategori = new KategoriProne(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]));
                                list.Add(kategori);
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