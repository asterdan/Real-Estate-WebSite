using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Adrese
    {
        [Display(Name="Adrese id")]
        public int adreseID { get; set; }
        [Display(Name="Rruge emer")]
        public string rrugeEmer { get; set; }
        [Display(Name="Ndertese numer")]
        public int nderteseNumer { get; set; }
        [Display(Name="Shkalle numer")]
        public int shkalleNumer { get; set; }
        [Display(Name="Apartament numer")]
        public int apartamentNumer { get; set; }
        [Display(Name="Pozicion gjeokrafik id")]
        public int pozicionGjeokrafik { get; set; }
        [Display(Name="Shtet id")]
        public int idShtet { get; set; }
        [Display(Name="Qytet id")]
        public int idQytet { get; set; }
        [Display(Name="Zip Code")]
        public int zipCode { get; set; }

        public Adrese()
        {

        }

        public Adrese(string _rrugeEmer,int _nderteseNumer,int _shkalleNumer,int _apartamentNumer,int _idShtet,int _idQytet,int _zipCode)
        {
            this.rrugeEmer = _rrugeEmer;
            this.nderteseNumer = _nderteseNumer;
            this.shkalleNumer = _shkalleNumer;
            this.apartamentNumer = _apartamentNumer;
            this.idShtet = _idShtet;
            this.idQytet = _idQytet;
            this.zipCode = _zipCode;
        }

        public Adrese(string _rrugeEmer, int _nderteseNumer, int _shkalleNumer, int _apartamentNumer,int _zipCode)
        {
            this.rrugeEmer = _rrugeEmer;
            this.nderteseNumer = _nderteseNumer;
            this.shkalleNumer = _shkalleNumer;
            this.apartamentNumer = _apartamentNumer;
            this.zipCode = _zipCode;
        }
    }
}