using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class ProneComponent
    {
        [Display(Name = "Prone Id")]
        private int idProne;
        [Display(Name = "Prone titull")]
        private String proneTitull;    
        [Display(Name = "Siperfaqe ")]
        private double proneSiperfaqe;     
        [Display(Name = "Numer dhomash")]
        private int proneNumerDhomash;      
        [Display(Name = "Numer banjo")]
        private int proneNumerBanjo;      
        [Display(Name = "Foto")]
        private String pronePicture;
        [Display(Name = "Cmim per muaj")]
        public double pricePerMonth { get; set; }
        [Display(Name = "Prone info id")]
        private int idProneInfo;
        public String picturePath { get; set; }

        
        [Display(Name = "E lire")]
        private int eLire;

        

        

        public int IdProne
        {
            get { return idProne; }
            set { idProne = value; }
        }

        public String ProneTitull
        {
            get { return proneTitull; }
            set { proneTitull = value; }
        }

        public double ProneSiperfaqe
        {
            get { return proneSiperfaqe; }
            set { proneSiperfaqe = value; }
        }

        public int ProneNumerDhomash
        {
            get { return proneNumerDhomash; }
            set { proneNumerDhomash = value; }
        }


        public int ProneNumerBanjo
        {
            get { return proneNumerBanjo; }
            set { proneNumerBanjo = value; }
        }


        public String PronePicture
        {
            get { return pronePicture; }
            set { pronePicture = value; }
        }

        public int IdProneInfo
        {
            get { return idProneInfo; }
            set { idProneInfo = value; }
        }

        public int ELire
        {
            get { return eLire; }
            set { eLire = value; }
        }

        public ProneComponent()
        {

        }

        public ProneComponent(int _id)
        {
            this.idProne = _id;
        }

        public ProneComponent(String _proneTitull,double _proneSiperfaqe,int _proneNumerDhomash,int _proneNumerBanjo)
        {
            this.proneTitull = _proneTitull;
            this.proneSiperfaqe = _proneSiperfaqe;
            this.proneNumerDhomash = _proneNumerDhomash;
            this.proneNumerBanjo = _proneNumerBanjo;
        }

        public ProneComponent(String _proneTitull, double _proneSiperfaqe, int _proneNumerDhomash, int _proneNumerBanjo,int _elire,double _cmimPerMuaj)
        {
            this.proneTitull = _proneTitull;
            this.proneSiperfaqe = _proneSiperfaqe;
            this.proneNumerDhomash = _proneNumerDhomash;
            this.proneNumerBanjo = _proneNumerBanjo;
            this.eLire = _elire;
            this.pricePerMonth = _cmimPerMuaj;
        }

        public ProneComponent(int _id,String _proneTitull, double _proneSiperfaqe, int _proneNumerDhomash, int _proneNumerBanjo)
        {
            this.idProne = _id;
            this.proneTitull = _proneTitull;
            this.proneSiperfaqe = _proneSiperfaqe;
            this.proneNumerDhomash = _proneNumerDhomash;
            this.proneNumerBanjo = _proneNumerBanjo;
        }

        public ProneComponent(int _idProne, String _proneTitull, double _proneSiperfaqe, int _proneNumerDhomash, String _pronePicture, double _pricePerMonth, int _idProneInfo)
        {
            this.idProne = _idProne;
            this.proneTitull = _proneTitull;
            this.proneSiperfaqe = _proneSiperfaqe;
            this.proneNumerDhomash = _proneNumerDhomash;
            this.pronePicture = _pronePicture;
            this.pricePerMonth = _pricePerMonth;
            this.idProneInfo = _idProneInfo;
        }

        public ProneComponent(int _idProne, String _proneTitull, double _proneSiperfaqe, int _proneNumerDhomash,int _proneNumerBanjo, double _pricePerMonth, int _idProneInfo,String picturePath)
        {
            this.idProne = _idProne;
            this.proneTitull = _proneTitull;
            this.proneSiperfaqe = _proneSiperfaqe;
            this.proneNumerDhomash = _proneNumerDhomash;
            this.proneNumerBanjo = _proneNumerBanjo;
            this.pricePerMonth = _pricePerMonth;
            this.idProneInfo = _idProneInfo;
            this.picturePath = picturePath;
        }





        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ProneComponent [");
            sb.Append("Prone titull: ");
            sb.Append(this.proneTitull);
            sb.Append("]");
            return sb.ToString();
        }


        
    }
}