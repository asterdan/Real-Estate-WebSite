using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class PozicionGjeografik
    {
        [Display(Name = "Pozicion id")]
        public int pozicionID { get; set; }
        [Display(Name = "Latitude")]
        public double latitude { get; set; }
        [Display(Name = "Logitude")]
        public double logitude { get; set; }

        public PozicionGjeografik()
        {

        }

        public PozicionGjeografik(double _latitude,double _logitude)
        {
            this.latitude = _latitude;
            this.logitude = _logitude;
        }
    }
}