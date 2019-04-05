using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class ProneInfo
    {
        [Display(Name = "Info id")]
        public int idInfo { get; set; }
        [Display(Name = "Vleresimi prones")]
        public double proneRating { get; set; }
        [Display(Name = "Adrese ")]
        public int idAdrese { get; set; }
        [Display(Name = "Pronar ")]
        public int idKonsumator { get; set; }
        [Display(Name = "Kategori")]
        public int idKategori { get; set; }

       
        public ProneInfo()
        {

        }

        public ProneInfo(double _proneRating)
        {
            this.proneRating = _proneRating;
        }

        public ProneInfo(double _proneRating, int _idKategori)
        {
            this.proneRating = _proneRating;
            this.idKategori = _idKategori;
        }

        public ProneInfo(int _idInfo, double _proneRating, int _idAdrese, int _idKonsumator, int _idKategori)
        {
            this.idInfo = _idInfo;
            this.proneRating = _proneRating;
            this.idAdrese = _idAdrese;
            this.idKonsumator = _idKonsumator;
            this.idKategori = _idKategori;
        }


        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ProneInfo [");
            sb.Append("Info id: ");
            sb.Append(idInfo);
            sb.Append(",Vleresimi prones : ");
            sb.Append(proneRating);
            sb.Append("]");

            return sb.ToString();
        }
    }
}