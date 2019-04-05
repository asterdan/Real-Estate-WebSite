using HomeWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Clients
{
    public class CommentDbClient
    {

        public void InsertComment(Comment comment)
        {
            using(SqlConnection con = new SqlConnection(Connection.String()))
            {
                using(SqlCommand cmd = new SqlCommand("sp_AddComment",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@comment",SqlDbType.VarChar).Value = comment.comment;
                    cmd.Parameters.Add("@idPerdorues",SqlDbType.Int).Value = comment.perdoruesId;
                    cmd.Parameters.Add("@idProne",SqlDbType.Int).Value = comment.proneId;
                    cmd.Parameters.Add("@userName",SqlDbType.VarChar).Value = comment.userName;
                    cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = comment.dateTime;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }

        public List<Comment> GetCommentsByProperty(int id)
        {
            List<Comment> comments = new List<Comment>();
            using (SqlConnection con = new SqlConnection(Connection.String()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPropertyComments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idProne", SqlDbType.Int).Value = id;
          
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                Comment comment = new Comment(Convert.ToInt32(reader["perdoruesId"]), Convert.ToInt32(reader["proneId"]), Convert.ToString(reader["comment"]),
                                    Convert.ToString(reader["perdoruesUserName"]), Convert.ToDateTime(reader["datetime"]));
                                comments.Add(comment);
                            }
                        }
                    }
                    con.Close();

                }
            }

            return comments;
        }
    }
}