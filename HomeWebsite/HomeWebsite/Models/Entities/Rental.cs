using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Rental
    {
        public int rentalID { get; set; }
        public int rentalCustomer { get; set; }
        public int rentalSeller { get; set; }
        public DateTime rentDate { get; set; }

        public Rental()
        {
            
        }

        public Rental(int _rentalCustomer, int _rentalSeller, DateTime _rentDate)
        {
            this.rentalCustomer = _rentalCustomer;
            this.rentalSeller = _rentalSeller;
            this.rentDate = _rentDate;
        }

        public Rental(int _rentalID,int _rentalCustomer,int _rentalSeller,DateTime _rentDate)
        {
            this.rentalID = _rentalID;
            this.rentalCustomer = _rentalCustomer;
            this.rentalSeller = _rentalSeller;
            this.rentDate = _rentDate;
        }
    }
}