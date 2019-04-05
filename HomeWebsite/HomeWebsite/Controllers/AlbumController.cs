using HomeWebsite.Models.Clients;
using HomeWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWebsite.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddImages(FormCollection collection)
        {
            int idProne = Convert.ToInt32(collection["idProne"]);
            Session["ProneId"] = idProne;
            return View();
        }

        public ActionResult ImageAdd(FormCollection collection)
        {
            int idProne = Convert.ToInt32(collection["idProne"]);
            Session["ProneId"] = idProne;
            return View();
        }

        [HttpPost]
        public ActionResult UploadFinish(IEnumerable<HttpPostedFileBase> files)
        {
            String message = "";
            String status = "";
            try
            {
                if (Session["ProneId"] != null)
                {
                    int id = Convert.ToInt32(Session["ProneId"]);
                    foreach (var file in files)
                    {
                        Photo foto = new Photo();
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);
                        fileName = fileName + extension;
                        foto.profilePicPath = "~/Album/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Album/"), fileName);
                        foto.profilePicName = fileName;
                        file.SaveAs(fileName);
                        PhotoDbClient photoDbClient = new PhotoDbClient();
                        photoDbClient.InsertToAlbum(foto, id);

                    }
                    message = "Files uploaded successfully!";
                    status = "success";
                }
            }
            catch(Exception ex)
            {
                status = "failed";
                message = "Something went wrong! " + ex.Message;
            }


            return Json(new { data = new { status = status, message = message } });
        }
    }
}