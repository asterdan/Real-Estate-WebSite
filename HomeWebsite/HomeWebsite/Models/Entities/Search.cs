using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Search
    {
        [Display(Name = "Qyteti")]
        private String qyteti;

        public String Qyteti
        {
            get { return qyteti; }
            set { qyteti = value; }
        }


        public Search()
        {

        }
    }
}