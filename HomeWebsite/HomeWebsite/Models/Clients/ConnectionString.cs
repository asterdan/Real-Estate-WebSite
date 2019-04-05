using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient; 

namespace HomeWebsite.Models.Clients
{
    public class Connection
    {
        public static String String()
        {
            String cs = WebConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            return cs;
        }
    }
}