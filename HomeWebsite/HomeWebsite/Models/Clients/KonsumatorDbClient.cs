using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeWebsite.Models.Entities;
using System.Data.SqlClient;
using System.Data;

namespace HomeWebsite.Models.Clients
{
    public class KonsumatorDbClient
    {
        public void Insert(Konsumator konsumator,Photo image)
        {
            
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("ShtoPerdorues", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = konsumator.UserName;
                    cmd.Parameters.Add("@emer", SqlDbType.VarChar).Value = konsumator.Emer;
                    cmd.Parameters.Add("@mbiemer", SqlDbType.VarChar).Value = konsumator.Mbiemer;
                    cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = konsumator.Telefon;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = konsumator.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = konsumator.Password;
                    cmd.Parameters.Add("@imageFileName", SqlDbType.VarChar).Value = image.profilePicName;
                    cmd.Parameters.Add("@imagePath", SqlDbType.VarChar).Value = image.profilePicPath;
                    cmd.Parameters.Add("@konsumatorPershkrim", SqlDbType.VarChar).Value = konsumator.KonsumatorPershkrim;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void InsertWithoutPhoto(Konsumator konsumator)
        {

            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("ShtoPerdoruesPaFoto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = konsumator.UserName;
                    cmd.Parameters.Add("@emer", SqlDbType.VarChar).Value = konsumator.Emer;
                    cmd.Parameters.Add("@mbiemer", SqlDbType.VarChar).Value = konsumator.Mbiemer;
                    cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = konsumator.Telefon;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = konsumator.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = konsumator.Password;
                    cmd.Parameters.Add("@konsumatorPershkrim", SqlDbType.VarChar).Value = konsumator.KonsumatorPershkrim;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public KonsumatorWithPicture GetKonsumatorById(int id)
        {
            KonsumatorWithPicture konsumator = new KonsumatorWithPicture();
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetKonsumatorById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if (reader.HasRows)
                        {
                            while(reader.Read())
                            {

                                Konsumator kons = new Konsumator(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]),
                                   Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToInt32(reader[10]), Convert.ToString(reader[13]));
                                Photo picture = new Photo(Convert.ToString(reader["profilePicName"]), Convert.ToString(reader["profilePicPath"]));
                                konsumator = new KonsumatorWithPicture(kons, picture);
                                
                            }
                        }
                        
                    }
                }
            }


            return konsumator;
        }

        public Konsumator GetLoginSession(Konsumator konsumator)
        {
            Konsumator kons = new Konsumator();
            int counter = 0;
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = konsumator.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = konsumator.Password;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                kons = new Konsumator(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]),
                                   Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToInt32(reader[10]), Convert.ToString(reader[13]));
                                
                                counter++;
                            }
                        }

                    }
                }
            }

            if (counter == 0)
            {
                kons = null;
            }

            return kons;
        }


        public bool CheckLogin(Konsumator konsumator)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = konsumator.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = konsumator.Password;

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

        public void UpdatePicture(int id,Photo photo)
        {
            using(SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UploadProfilePicture",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id",SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = photo.profilePicName;
                    cmd.Parameters.Add("@path", SqlDbType.VarChar).Value = photo.profilePicPath;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                     
                }
            }
        }

        public void AddAdress(int id,Adrese adrese)
        {
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddUserAddress", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@rrugeEmer", SqlDbType.VarChar).Value = adrese.rrugeEmer;
                    cmd.Parameters.Add("@nderteseNumer", SqlDbType.Int).Value = adrese.nderteseNumer;
                    cmd.Parameters.Add("@shkalleNumer", SqlDbType.Int).Value = adrese.shkalleNumer;
                    cmd.Parameters.Add("@apartamentNumer", SqlDbType.Int).Value = adrese.apartamentNumer;
                    cmd.Parameters.Add("@idQytet", SqlDbType.Int).Value = adrese.idQytet;
                    cmd.Parameters.Add("@idShtet", SqlDbType.Int).Value = adrese.idShtet;
                    cmd.Parameters.Add("@zipCode", SqlDbType.Int).Value = adrese.zipCode;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }

        public void AddCreditCard(int id,CreditCard card)
        {
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand cmd = new SqlCommand("sp_AddCreditCard",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@cardHolder", SqlDbType.VarChar).Value = card.cardHolder;
                    cmd.Parameters.Add("@cardNumber", SqlDbType.VarChar).Value = card.cardNumber;
                    cmd.Parameters.Add("@expiration", SqlDbType.Date).Value = card.expires;
                    cmd.Parameters.Add("@secCode", SqlDbType.VarChar).Value = card.securityCode;
                    cmd.Parameters.Add("@zipCode", SqlDbType.VarChar).Value = card.zipCode;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}