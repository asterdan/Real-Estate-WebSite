using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Shtet
    {
        [Display(Name="Shtet id")]
        public int shtetID { get; set; }
        [Display(Name="Shtet emer")]
        public String shtetEmer { get; set; }

        public Shtet()
        {

        }

        public Shtet(int _shtetID,String _shtetEmer)
        {
            this.shtetID = _shtetID;
            this.shtetEmer = _shtetEmer;
        }
    }
}