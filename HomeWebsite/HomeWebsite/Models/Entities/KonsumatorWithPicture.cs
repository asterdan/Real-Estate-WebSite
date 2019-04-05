using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class KonsumatorWithPicture
    {
        public Konsumator konsumator { get; set; }
        public Photo picture { get; set; }

        public KonsumatorWithPicture()
        {

        }

        public KonsumatorWithPicture(Konsumator _konsumator,Photo _pic)
        {
            this.konsumator = _konsumator;
            this.picture = _pic;
        }
    }
}