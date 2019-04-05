using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class Comment
    {
        public int commentId { get; set; }
        public int perdoruesId { get; set; }
        public int proneId { get; set; }
        public string userName { get; set; }
        public string comment { get; set; }
        public DateTime dateTime { get; set; }

        public Comment()
        {

        }

        public Comment(int idPerdorues,int idProne,string _comment,string _userName,DateTime time)
        {
            this.perdoruesId = idPerdorues;
            this.proneId = idProne;
            this.comment = _comment;
            this.userName = _userName;
            this.dateTime = time;
        }
    }
}