using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class CreditCard
    {
        [Display(Name="Credit card id")]
        public int cardId { get; set; }
        [Display(Name = "Card holder")]
        public String cardHolder { get; set; }
        [Display(Name = "Card number")]
        public String cardNumber { get; set; }
        [Display(Name = "Expires")]
        public DateTime expires { get; set; }
        [Display(Name = "Security Code")]
        public String securityCode { get; set; }
        [Display(Name = "Zip Code")]
        public String zipCode { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(String _cardHolder,String _cardNumber,DateTime _expires,String _securityCode,String _zipCode)
        {
            this.cardHolder = _cardHolder;
            this.cardNumber = _cardNumber;
            this.expires = _expires;
            this.securityCode = _securityCode;
            this.zipCode = _zipCode;
        }
    }
}