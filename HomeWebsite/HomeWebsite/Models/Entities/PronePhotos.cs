using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class PronePhoto
    {
        [Display(Name = "Foto id")]
        public int idPhoto { get; set; }
        [Display(Name = "Emer foto")]
        public String photoName { get; set; }
        [Display(Name = "Foto path")]
        public String photoPath { get; set; }
        [Display(Name = "Prone Id")]
        public int idProne { get; set; }

        public HttpPostedFile ImageFile { get; set; }
       
        public PronePhoto()
        {

        }

        public PronePhoto(String _photoName,String _photoPath,int _idProne)
        {
            this.photoName = _photoName;
            this.photoPath = _photoPath;
            this.idProne = _idProne;
        }
    }
}