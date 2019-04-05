using HomeWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using HomeWebsite.Models.Entities;


namespace HomeWebsite.Models.Clients
{
    public class OrderClient
    {
        public void InsertOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertOrder",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rentalCustomer", SqlDbType.Int).Value = order.rentalComp.rentalCustomer;
                    cmd.Parameters.Add("@rentalSeller", SqlDbType.Int).Value = order.rentalComp.rentalSeller;
                    cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = order.rentalComp.rentDate;
                    cmd.Parameters.Add("@pricePerMonth", SqlDbType.Real).Value = order.details.pricePerMonth;
                    cmd.Parameters.Add("@proneId", SqlDbType.Int).Value = order.details.proneId;
                    cmd.Parameters.Add("@sasiMuajsh", SqlDbType.Int).Value = order.details.sasiMuajsh;
                    cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = order.details.endDate;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = order.details.description;
                    cmd.Parameters.Add("@total", SqlDbType.Real).Value = order.details.total;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}