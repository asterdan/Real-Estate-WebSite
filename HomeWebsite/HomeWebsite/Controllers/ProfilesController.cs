using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Clients;
using HomeWebsite.Models.Entities;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace HomeWebsite.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            if (Session["Perdorues"] != null)
            {
                Konsumator kons = new Konsumator();
                try
                {
                    kons = (Konsumator)Session["Perdorues"];

                    KonsumatorDbClient konsumatorClient = new KonsumatorDbClient();
                    KonsumatorWithPicture konsumator = konsumatorClient.GetKonsumatorById(kons.IdKonsumator);
                    ViewBag.Data = konsumator;

                    if (konsumator.picture.profilePicPath == "")
                    {
                        ViewBag.Src = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6CgVGg5OjY7d64jvpXLs4MsWpykLmzOa_I6ClH2zLvycZ5J2c4g";
                    }
                    else
                    {
                        ViewBag.Src = konsumator.picture.profilePicPath;
                    }

                    SearchOperations ops = new SearchOperations();
                    List<Prone> prona = ops.GetByUserId(kons.IdKonsumator);
                    ViewBag.Properties = prona;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = kons.IdKonsumator + "Something went wrong! " + ex.Message;
                }

            }
            else
            {
                Session["Action"] = "UserProfile";
                Session["Controller"] = "Profiles";
                return RedirectToAction("LoginForm", "Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            if (Session["Perdorues"] != null)
            {
                Konsumator kons = new Konsumator();
                try
                {
                    kons = (Konsumator)Session["Perdorues"];

                    KonsumatorDbClient konsumatorClient = new KonsumatorDbClient();
                    KonsumatorWithPicture konsumator = konsumatorClient.GetKonsumatorById(kons.IdKonsumator);
                    ViewBag.Data = konsumator;

                    if (konsumator.picture.profilePicPath == "")
                    {
                        ViewBag.Src = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6CgVGg5OjY7d64jvpXLs4MsWpykLmzOa_I6ClH2zLvycZ5J2c4g";
                    }
                    else
                    {
                        ViewBag.Src = konsumator.picture.profilePicPath;
                    }

                    SearchOperations ops = new SearchOperations();
                    List<Prone> prona = ops.GetByUserId(kons.IdKonsumator);
                    ViewBag.Properties = prona;
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = kons.IdKonsumator + "Something went wrong! " + ex.Message;
                }
                
            }
            else
            {
                Session["Action"] = "MyProfile";
                Session["Controller"] = "Profiles";
                return RedirectToAction("LoginForm", "Login");
            }
            
            return View();
        }


        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase file)
        {
            try
            {
                Photo foto = new Photo();
                Konsumator kons = (Konsumator)Session["Perdorues"];
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + extension;
                foto.profilePicPath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                foto.profilePicName = fileName;
                file.SaveAs(fileName);
                KonsumatorDbClient client = new KonsumatorDbClient();
                client.UpdatePicture(kons.IdKonsumator, foto);
                ViewBag.ErroMessage = "Picture updated!";

                return Json(new { data = new  { status = "success", message = "Picture updated!" } });
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                return Json(new { data = new  { status = "error" , message = "Something went wrong! " + ex.Message } });
            }
            
        }

        [HttpGet]
        public ActionResult AddAddress()
        {
            if (Session["Perdorues"]!=null)
            {
                QytetDbClient qdbClient = new QytetDbClient();
                ViewBag.Cities = qdbClient.GetCities();
                ShtetDbClient shdbClient = new ShtetDbClient();
                ViewBag.Countries = shdbClient.GetCountries();

                Konsumator kon = (Konsumator)Session["Perdorues"];
                int id = kon.IdKonsumator;
            }
            else
            {
                Session["Action"] = "AddAddress";
                Session["Controller"] = "Profiles";
                return RedirectToAction("LoginForm", "Login");
            }
            

            return View();
        }

        [HttpPost]
        public ActionResult InsertAddress(FormCollection collection)
        {
            if (Session["Perdorues"] != null)
            {
                Konsumator kons = (Konsumator)Session["Perdorues"];
                int id = kons.IdKonsumator;
                String rrugeEmer = collection["rrugeTxt"];
            int ndertese = Convert.ToInt32(collection["nderteseTxt"]);
            int shkalle = Convert.ToInt32(collection["shkalleTxt"]);
            int apartament = Convert.ToInt32(collection["apartamentTxt"]);
            int shtetid = Convert.ToInt32(collection["shtetiTxt"]);
            int qytetId = Convert.ToInt32(collection["qytetiTxt"]);
            int zipCode = Convert.ToInt32(collection["ziptTxt"]);

            Adrese adrese = new Adrese(rrugeEmer, ndertese, shkalle, apartament, shtetid, qytetId, zipCode);

            try
            {
                KonsumatorDbClient consDbClient = new KonsumatorDbClient();
                consDbClient.AddAdress(id, adrese);
                return Json( new { status = "success" , message = "address added!"});
            }
                catch(Exception ex)
            {
                return Json(new { status = "error", message = "something went wrong! " + ex.Message });
            }
            }
            else
            {
                Session["Action"] = "AddAddress";
                Session["Controller"] = "Profiles";
                return RedirectToAction("LoginForm", "Login");
            }
        }

        [HttpGet]
        public ActionResult AddCreditCard()
        {
            if(Session["Perdorues"]!=null)
            {
                Konsumator kon = (Konsumator)Session["Perdorues"];
            }
            else
            {
                Session["Action"] = "AddCreditCard";
                Session["Controller"] = "Profiles";
                return RedirectToAction("LoginForm", "Login");
            }

            return View();
            
        }

        [HttpPost]
        public ActionResult CreditCardInsertion(FormCollection collection)
        {
            if (Session["Perdorues"] != null)
            {
                try
                {
                    Konsumator kon = (Konsumator)Session["Perdorues"];
                    int id = kon.IdKonsumator;
                    String cardHolder = collection["cardHolderTxt"];
                    String cardNumber = collection["cardNumberTxt"];
                    String month = collection["monthTxt"];
                    String year = collection["yearTxt"];
                    string date = "01/" + month + "/" + year;

                    DateTime dateDb = Convert.ToDateTime(date);
                    String secCode = collection["securityCodeTxt"];
                    String zipcode = collection["zipCodeTxt"];

                    CreditCard card = new CreditCard(cardHolder, cardNumber, dateDb, secCode, zipcode);

                    KonsumatorDbClient dbClient = new KonsumatorDbClient();
                    dbClient.AddCreditCard(id, card);

                    return Json(new { status = "success", message = "credit card inserted!" });
                }
                catch(Exception ex)
                {
                    return Json(new { status="failed", message="something went wrong! " + ex.Message});
                }
                
            }
            else
            {
                Session["Action"] = "CreditCardInsertion";
                Session["Controller"] = "Profiles";
                return RedirectToAction("LoginForm", "Login");
                
            }
        }

            
        
    }
}