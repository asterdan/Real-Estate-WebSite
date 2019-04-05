using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;
using System.IO;

namespace HomeWebsite.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public ActionResult AddProfilePic(Konsumator konsumator)
        {
            TempData["konsumator"] = konsumator;         
            return View();
        }

        [HttpPost]
        public ActionResult UserRegisterCompletition(Photo image)
        {

            try
            {
                try
                {
                    string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                    string extension = Path.GetExtension(image.ImageFile.FileName);
                    fileName = fileName + extension;
                    image.profilePicPath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image.ImageFile.SaveAs(fileName);
                    KonsumatorDbClient consumatorDbClient = new KonsumatorDbClient();
                    consumatorDbClient.Insert((Konsumator)TempData["konsumator"], image);
                    ViewBag.ErrorMessage = "User registered successfully with profile picture!";
                }
                catch (NullReferenceException ex)
                {
                    KonsumatorDbClient consumatorDbClient = new KonsumatorDbClient();
                    consumatorDbClient.InsertWithoutPhoto((Konsumator)TempData["konsumator"]);
                    ViewBag.ErrorMessage = "User registered successfully! Without profile picture! " + ex.Message;
                }      
            }
            catch(SqlException ex)
            {
                ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
            }
            

            return View();
        }
    }
}