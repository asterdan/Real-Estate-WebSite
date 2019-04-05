using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Photo
    {
        [Display(Name="Emer foto")]
        public String profilePicName { get; set; }
        [Display(Name="Path foto")]
        public String profilePicPath { get; set; }
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase ImageFile { get; set; }
        

        public Photo()
        {

        }

        public Photo(String _picName,String _picPath)
        {
            this.profilePicName = _picName;
            this.profilePicPath = _picPath;
        }

        public Photo(String _picName,String _picPath,HttpPostedFileBase _imageFile)
        {
            this.profilePicName = _picName;
            this.profilePicPath = _picPath;
            this.ImageFile = _imageFile;
        }

        public bool IsEmpty()
        {
            if (profilePicName == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}