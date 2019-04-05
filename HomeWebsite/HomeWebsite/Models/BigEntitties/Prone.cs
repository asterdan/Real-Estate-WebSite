using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Prone
    {
        [Display(Name = "Prone ")]
        public ProneComponent proneComp { get;set; }
        [Display(Name = "Prone info")]
        public ProneInfo info { get; set; }
        [Display(Name = "Adresa")]
        public Adrese adresa;
        [Display(Name = "Vendndodhja")]
        public PozicionGjeografik pozicioni;
        [Display(Name = "Kategoria")]
        public KategoriProne kategori;
        [Display(Name = "Pronar")]
        public Konsumator pronar;
        [Display(Name = "Fotot")]
        public List<PronePhoto> photos;



        public Prone()
        {

        }

        public Prone(ProneComponent comp,ProneInfo info)
        {
            this.proneComp = comp;
            this.info = info;
        }

        public String toString()
        {
            return proneComp.toString() + "  " + info.toString();
        }
    }
}