using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using HomeWebsite.Models.Entities;

namespace HomeWebsite.Models.Clients
{
    public class SearchOperations
    {

        public List<Prone> SearchByCity(Search search)
        {
            List<Prone> list = new List<Prone>();
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand  cmd = new SqlCommand("sp_SearchHouseByCity",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = search.Qyteti;

                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                ProneComponent newProneComp = new ProneComponent(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDouble(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]), Convert.ToDouble(reader["pricePerMonth"]), 0, Convert.ToString(reader["pronePicturePath"]));
                                ProneInfo pInfo = new ProneInfo(Convert.ToDouble(reader[9]));
                                Prone newProne = new Prone(newProneComp, pInfo);
                                list.Add(newProne);
                            }
                        }
                    }
                }
            }

            return list;
        }


        public bool HasRecordsByCity(Search search)
        {
            List<Prone> list = new List<Prone>();
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SearchHouseByCity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = search.Qyteti;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
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


        public List<Prone> GetByUserId(int id)
        {
            List<Prone> list = new List<Prone>();
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPropertiesByUserId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProneComponent newProneComp = new ProneComponent(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDouble(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]), Convert.ToDouble(reader["pricePerMonth"]), 0,Convert.ToString(reader["pronePicturePath"]));
                                ProneInfo pInfo = new ProneInfo(Convert.ToDouble(reader[9]));
                                Prone newProne = new Prone(newProneComp, pInfo);
                                list.Add(newProne);
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}