using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;

namespace HomeWebsite.Controllers
{
    public class ProneInformationController : Controller
    {
        // GET: ProneInformation
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult MoreInfo(FormCollection collection)
        {

                ViewBag.Images = null;
                ViewBag.Comments = null;
                int id = Convert.ToInt32(collection["propertyTxt"]);
                try
                {
                    ProneDbClient dbClient = new ProneDbClient();
                    PhotoDbClient fotoDbClient = new PhotoDbClient();
                    CommentDbClient commentDbClient = new CommentDbClient();
                    try
                    {
                        
                        if (dbClient.Exists(id))
                        {
                            ProneFullInformation fullInfo = dbClient.GetProneById(id);
                            ViewBag.Information = fullInfo;
                            
                            
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Nothing found in the database!";
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                    }

                    try
                    {
                        if(dbClient.Exists(id))
                        {
                            ViewBag.Images = fotoDbClient.SelectAlbum(id);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                        ViewBag.Status = "false";


                    }


                    try
                    {
                        if (dbClient.Exists(id))
                        {
                            ViewBag.Comments = commentDbClient.GetCommentsByProperty(id);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                        ViewBag.Status = "false";
                    }
                   
                }
                catch (SqlException ex)
                {
                    ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                }

            
            

            return View();
        }



        [HttpPost]
        public ActionResult PostComment(FormCollection collection)
        {
            try
            {
                string commentTxt = collection["commentTxt"];
                int userId = Convert.ToInt32(collection["userId"]);
                int propertyId = Convert.ToInt32(collection["propertyId"]);
                string userName = collection["userName"];
                DateTime now = DateTime.Now;

                Comment comment = new Comment(userId, propertyId, commentTxt, userName, now);
                CommentDbClient commentDbClient = new CommentDbClient();
                commentDbClient.InsertComment(comment);

                return Json(new { data = new { status = "success", message = "Comment added!" } });
            }
            catch(Exception ex)
            {
                return Json(new { data = new { status = "failure", message = "Something went wrong!" + ex.Message } });
            }
            


            return View();
        }

        [HttpPost]
        public ActionResult AddPropertyPicture(int id)
        {
            Session["PropertyId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase file)
        {
            try
            {
                if (Session["PropertyId"] != null)
                {
                    int id = Convert.ToInt32(Session["PropertyId"]);
                    Photo foto = new Photo();
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    fileName = fileName + extension;
                    foto.profilePicPath = "~/PropertyImages/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/PropertyImages/"), fileName);
                    foto.profilePicName = fileName;
                    file.SaveAs(fileName);
                    ProneRegistrationDbClient proneDbClient = new ProneRegistrationDbClient();
                    proneDbClient.UpdateProfilePicture(id, foto);
                    return Json(new { status = "Success!", message = file.FileName + " uploaded successfully!" });
                }
                else
                {
                    return Json(new { status = "Failed!", message = "No record selected!" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { status = "Failed!", message = "Something went wrong! " + ex.Message + " " + ex.StackTrace });
            }



        }

    }
}