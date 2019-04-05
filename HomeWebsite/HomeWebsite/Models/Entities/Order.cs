using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Order
    {
        public ProneComponent proneComponent { get; set; }
        public Rental rentalComp { get; set; }
        public RentalDetails details { get; set; }

        public Order()
        {

        }

        public Order(Rental _rentalCom,RentalDetails _details)
        {
            this.rentalComp = _rentalCom;
            this.details = _details;
        }
        public Order(ProneComponent _prone,Rental _rentalCom, RentalDetails _details)
        {
            this.proneComponent = _prone;
            this.rentalComp = _rentalCom;
            this.details = _details;
        }

    }
}