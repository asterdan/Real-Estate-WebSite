using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;
using System.Data;

namespace HomeWebsite.Models.Clients
{
    public class ProneRegistrationDbClient
    {

        public void Insert(PozicionGjeografik pozicion,Adrese addres,ProneInfo info,ProneComponent component,int idUser,Photo image)
        {
            using(SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand cmd = new SqlCommand("sp_InsertProne",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@latitude",SqlDbType.Real).Value = pozicion.latitude;
                    cmd.Parameters.Add("@logitude", SqlDbType.Real).Value = pozicion.logitude;
                    cmd.Parameters.Add("@rrugeEmer",SqlDbType.VarChar).Value = addres.rrugeEmer;
                    cmd.Parameters.Add("@nderteseNumer",SqlDbType.Int).Value = addres.nderteseNumer;
                    cmd.Parameters.Add("@shkalleNumer",SqlDbType.Int).Value = addres.shkalleNumer;
                    cmd.Parameters.Add("@apartamentNumer",SqlDbType.Int).Value = addres.apartamentNumer;
                    cmd.Parameters.Add("@idQytet",SqlDbType.Int).Value = addres.idQytet;
                    cmd.Parameters.Add("@idShtet",SqlDbType.Int).Value = addres.idShtet;
                    cmd.Parameters.Add("@zipCode",SqlDbType.Int).Value = addres.zipCode;
                    cmd.Parameters.Add("@proneRating",SqlDbType.Decimal).Value = info.proneRating;
                    cmd.Parameters.Add("@idKonsumator",SqlDbType.Int).Value = idUser;
                    cmd.Parameters.Add("@idKategori",SqlDbType.Int).Value = info.idKategori;
                    cmd.Parameters.Add("@proneTitull",SqlDbType.VarChar).Value = component.ProneTitull;
                    cmd.Parameters.Add("@proneSiperfaqe",SqlDbType.Decimal).Value = component.ProneSiperfaqe;
                    cmd.Parameters.Add("@proneNumerDhomash",SqlDbType.Int).Value = component.ProneNumerDhomash;
                    cmd.Parameters.Add("@proneNumerBanjo",SqlDbType.Int).Value = component.ProneNumerBanjo;
                    cmd.Parameters.Add("@eLire",SqlDbType.Bit).Value = component.ELire;
                    cmd.Parameters.Add("@pronePicture", SqlDbType.VarChar).Value = image.profilePicName;
                    cmd.Parameters.Add("@pronePicturePath", SqlDbType.VarChar).Value = image.profilePicPath;
                    cmd.Parameters.Add("@pricePerMonth", SqlDbType.Decimal).Value = component.pricePerMonth;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


         public void UpdateProfilePicture(int idProperty,Photo image)
         {
            using(SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddPropertyPicture", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idProperty;
                    cmd.Parameters.Add("@picName", SqlDbType.VarChar).Value = image.profilePicName;
                    cmd.Parameters.Add("@picPath", SqlDbType.VarChar).Value = image.profilePicPath;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
         }
    }
}

   
