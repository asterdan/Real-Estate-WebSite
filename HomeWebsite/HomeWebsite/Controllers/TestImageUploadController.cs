using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;
using HomeWebsite.Models;
using System.IO;

namespace HomeWebsite.Controllers
{
    public class TestImageUploadController : Controller
    {
        // GET: TestImageUpload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPhoto()
        {
            return View();
        }

        public ActionResult UploadComplete(PronePhoto image)
        {


            return View();
        }

        public ActionResult TestDragDrop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            foreach(var file in files)
            {
                string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/Images"), filePath));
                //Here you can write code for save this information in your database
            }

            return Json("file uploaded successfully");
        }
    }
}