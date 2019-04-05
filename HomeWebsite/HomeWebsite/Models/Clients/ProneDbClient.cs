using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeWebsite.Models.Entities;
using System.Data.SqlClient;
using System.Data;

namespace HomeWebsite.Models.Clients
{
    public class ProneDbClient
    {
        public bool Exists(int id)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectPropertyById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            flag = true;

                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }
            return flag;
        }

        public ProneFullInformation GetProneById(int id)
        {
            ProneFullInformation fullInformation = new ProneFullInformation();
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectPropertyById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            KonsumatorDbClient konsumatorDbClient = new KonsumatorDbClient();
                           
                            Qytet city = new Qytet(Convert.ToInt32(reader["qytetID"]), Convert.ToString(reader["qytetEmer"]), 0);
                            PozicionGjeografik geo = new PozicionGjeografik(Convert.ToDouble(reader["latitude"]), Convert.ToDouble(reader["logitude"]));
                            Adrese adrese = new Adrese(Convert.ToString(reader["rrugeEmer"]), Convert.ToInt32(reader["nderteseNumer"]), Convert.ToInt32(reader["shkalleNumer"]),
                                Convert.ToInt32(reader["apartamentNumer"]), Convert.ToInt32(reader["zipCode"]));
                            Konsumator konsumator = new Konsumator(Convert.ToInt32(reader["idKonsumator"]), Convert.ToDouble(reader["konsumatorRating"]), Convert.ToString(reader["konsumatorPershkrim"]));
                            KonsumatorWithPicture konsumatorFull = konsumatorDbClient.GetKonsumatorById(konsumator.IdKonsumator);
                            KategoriProne kategori = new KategoriProne(0, Convert.ToString(reader["kategoriProneEmer"]), Convert.ToString(reader["kategoriPershkrim"]));
                            ProneInfo info = new ProneInfo(Convert.ToDouble(reader["proneRating"]));
                            ProneComponent comp = new ProneComponent(id, Convert.ToString(reader["proneTitull"]), Convert.ToDouble(reader["proneSiperfaqe"]), Convert.ToInt32(reader["proneNumerDhomash"]), Convert.ToInt32(reader["proneNumerBanjo"]), Convert.ToDouble(reader["pricePerMonth"]), 0,Convert.ToString(reader["pronePicturePath"]));
                            Photo foto = new Photo(Convert.ToString(reader["pronePicture"]), Convert.ToString(reader["pronePicturePath"]));
                            fullInformation = new ProneFullInformation(comp, info, kategori, konsumatorFull, adrese, geo, city,foto);
                        }
                    }
                }
            }
            return fullInformation;
        }
    }
}