using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Konsumator : Perdorues
    {
        [Display(Name="Konsumator id")]
        private int idKonsumator;
        [Display(Name = "Credit card info")]
        private int creditCardInfo;
        [Display(Name = "Konsumator rating")]
        private double konsumatorRating;
        [Display(Name = "Konsumator pershkrim")]
        private String konsumatorPershkrim;


        public String KonsumatorPershkrim
        {
            get { return konsumatorPershkrim; }
            set { konsumatorPershkrim = value; }
        }

        public double KonsumatorRating
        {
            get { return konsumatorRating; }
            set { konsumatorRating = value; }
        }


        public int CreditCardInfo
        {
            get { return creditCardInfo; }
            set { creditCardInfo = value; }
        }

        public int IdKonsumator
        {
            get { return idKonsumator; }
            set { idKonsumator = value; }
        }

        public Konsumator()
        {

        }

        public Konsumator(int _idKonsumator,double _rating,String _pershkrim)
        {
            this.idKonsumator = _idKonsumator;
            this.konsumatorRating = _rating;
            this.konsumatorPershkrim = _pershkrim;
        }

        public Konsumator(String _userName,String _emer,String _mbiemer,String _telefon,String _email,String _password,String _konsumatorPershkrim) //Konstruktor per shtim perdoruesi te ri
            :base(_userName,_emer,_mbiemer,_telefon,_email,_password)
        {
            this.konsumatorPershkrim = _konsumatorPershkrim;
        }

        public Konsumator(int _idPerdorues,String _userName, String _emer, String _mbiemer, String _telefon, String _email, String _password,int _idKonsumator, String _konsumatorPershkrim) //Konstruktor per shtim perdoruesi te ri
            : base(_idPerdorues,_userName, _emer, _mbiemer, _telefon, _email, _password)
        {
            this.idKonsumator = _idKonsumator;
            this.konsumatorPershkrim = _konsumatorPershkrim;
        }


        public Konsumator(int _idPerdorues, String _userName, String _emer, String _mbiemer, String _telefon, String _email, String _password, int _idKonsumator, String _konsumatorPershkrim,double _konsumatorRating) //Konstruktor per shtim perdoruesi te ri
            : base(_idPerdorues, _userName, _emer, _mbiemer, _telefon, _email, _password)
        {
            this.idKonsumator = _idKonsumator;
            this.konsumatorPershkrim = _konsumatorPershkrim;
            this.konsumatorRating = _konsumatorRating;
        }

    
    }
}