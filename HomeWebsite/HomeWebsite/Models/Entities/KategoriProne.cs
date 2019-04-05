using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class KategoriProne
    {
        [Display(Name="Kategori id")]
        public int idKategori { get; set; }
        [Display(Name = "Kategori prone")]
        public String kategoriProneEmer { get; set; }
        [Display(Name = "Kategori pershkrim")]
        public String kategoriPershkrim { get; set; }

        public KategoriProne()
        {

        }

        public KategoriProne(int _idKategori,String _kategoriEmer,String _kategoriPershkrim)
        {
            this.idKategori = _idKategori;
            this.kategoriProneEmer = _kategoriEmer;
            this.kategoriPershkrim = _kategoriPershkrim;
        }
    }
}