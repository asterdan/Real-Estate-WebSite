using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Qytet
    {
        [Display(Name = "Qytet id")]
        public int qytetID { get; set; }
        [Display(Name = "Qytet emer")]
        public String qytetEmer { get; set; }
        [Display(Name = "Shtet id")]
        public int shtetID { get; set; }

        public Qytet()
        {

        }

        public Qytet(int _qytetId,String _qytetEmer,int _shtetID)
        {
            this.qytetID = _qytetId;
            this.qytetEmer = _qytetEmer;
            this.shtetID = _shtetID;
        }
    }


}