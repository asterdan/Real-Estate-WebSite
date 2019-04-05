using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Perdorues
    {
        [Display(Name = "Perdorues id")]
        protected int idPerdorues;
        [Display(Name = "Username")]
        protected String userName;
        [Display(Name = "Emer")]
        protected String emer;
        [Display(Name = "Mbiemer")]
        protected String mbiemer;
        [Display(Name = "Telefon")]
        protected String telefon;
        [Display(Name = "Email")]
        protected String email;
        [Display(Name = "Password")]
        protected String password;
        [Display(Name = "Profile picture")]
        protected String profilePic;
        [Display(Name = "Adrese")]
        protected int adrese;

        public int IdPerdorues
        {
            get { return idPerdorues; }
            set { idPerdorues = value; }
        }


        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public String Emer
        {
            get { return emer; }
            set { emer = value; }
        }

        public String Mbiemer
        {
            get { return mbiemer; }
            set { mbiemer = value; }
        }

        public String Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }


        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }


        public String ProfilePic
        {
            get { return profilePic; }
            set { profilePic = value; }
        }


        public int Adrese
        {
            get { return adrese; }
            set { adrese = value; }
        }





       
        

      

        

        

       

        public Perdorues()
        {
        }

        public Perdorues(int _idPerdorues)
        {
            this.idPerdorues = _idPerdorues;
        }

        public Perdorues(String _userName,String _emer,String _mbiemer,String _telefon,String _email,String _password)
        {
            this.userName = _userName;
            this.emer = _emer;
            this.mbiemer = _mbiemer;
            this.telefon = _telefon;
            this.email = _email;
            this.password = _password;
        }

        public Perdorues(int _idPerdorues,String _userName, String _emer, String _mbiemer, String _telefon, String _email, String _password)
        {
            this.idPerdorues = _idPerdorues;
            this.userName = _userName;
            this.emer = _emer;
            this.mbiemer = _mbiemer;
            this.telefon = _telefon;
            this.email = _email;
            this.password = _password;
        }
    }
}