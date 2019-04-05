using HomeWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace HomeWebsite.Models.Clients
{
    public class PhotoDbClient
    {
        public void InsertToAlbum(Photo image,int proneId)
        {
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand cmd = new SqlCommand("sp_AddPictureToProperty",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@photoPath", SqlDbType.VarChar).Value = image.profilePicPath;
                    cmd.Parameters.Add("@photoName", SqlDbType.VarChar).Value = image.profilePicName;
                    cmd.Parameters.Add("@idProne", SqlDbType.Int).Value = proneId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public List<Photo> SelectAlbum(int proneId)
        {
            List<Photo> list = new List<Photo>();
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectAlbumByIdProne", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = proneId;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                Photo image = new Photo(Convert.ToString(reader["photoName"]), Convert.ToString(reader["photoPath"]));
                                list.Add(image);
                            }
                        }
                    }
                    con.Close();
                }
            }

            return list;
        }


        public bool  HasAlbum(int proneId)
        {
            bool flag = true;
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectAlbumByIdProne", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = proneId;

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
                    con.Close();
                }
            }

            return flag;
        }
    }
}