using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class RentalDetails
    {
        public int rentalDetailsId{ get; set;}
        public int rentalId {get; set;}
        public double pricePerMonth { get; set; }
        public int proneId {get;set ;}
        public int sasiMuajsh { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
        public double total { get; set; }

        public RentalDetails()
        {

        }

        public RentalDetails(double _pricePerMonth, int _proneId, int _sasiMuajsh, DateTime _startDate, DateTime _endDate, string _descritption, double _total)
        {
            this.pricePerMonth = _pricePerMonth;
            this.proneId = _proneId;
            this.sasiMuajsh = _sasiMuajsh;
            this.startDate = _startDate;
            this.endDate = _endDate;
            this.description = _descritption;
            this.total = _total;
        }

        public RentalDetails(int _rentalId,double _pricePerMonth,int _proneId,int _sasiMuajsh,DateTime _startDate,DateTime _endDate,string _descritption,double _total)
        {
            this.rentalId = _rentalId;
            this.pricePerMonth = _pricePerMonth;
            this.proneId = _proneId;
            this.sasiMuajsh = _sasiMuajsh;
            this.startDate = _startDate;
            this.endDate = _endDate;
            this.description = _descritption;
            this.total = _total;
        }

        public RentalDetails(int _rentalDetailsId,int _rentalId, double _pricePerMonth, int _proneId, int _sasiMuajsh, DateTime _startDate, DateTime _endDate, string _descritption, double _total)
        {
            this.rentalDetailsId = _rentalDetailsId;
            this.rentalId = _rentalId;
            this.pricePerMonth = _pricePerMonth;
            this.proneId = _proneId;
            this.sasiMuajsh = _sasiMuajsh;
            this.startDate = _startDate;
            this.endDate = _endDate;
            this.description = _descritption;
            this.total = _total;
        }
    }
}