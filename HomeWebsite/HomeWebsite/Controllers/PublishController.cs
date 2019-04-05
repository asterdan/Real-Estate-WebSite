using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace HomeWebsite.Controllers
{
    public class PublishController : Controller
    {
       


        // GET: Publish
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddLocation()
        {
            if (Session["Perdorues"] != null)
            {
                Session["Action"] = null;
                Session["Controller"] = null;
            }
            else
            {
                Session["Action"] = "AddLocation";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }
            return View();
        }

        public ActionResult AddPhoto(PozicionGjeografik pozicion)
        {
            if (Session["Perdorues"]!=null)
            {
                TempData["pozicioni"] = pozicion;
            }
            else
            {
                Session["Action"] = "AddPhoto";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }
            
            return View();
        }

        public ActionResult AddAdress(Photo image)
        {
            
            if (Session["Perdorues"] != null)
            {

                

                
                ShtetDbClient shtetClient = new ShtetDbClient();
                QytetDbClient qytetClient = new QytetDbClient();

                try
                {
                    ViewBag.Countries = shtetClient.GetCountries();
                    ViewBag.Cities = qytetClient.GetCities();
                    ViewBag.Flag = true;
                }
                catch (SqlException ex)
                {
                    ViewBag.Flag = false;
                    ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                }



                
                TempData["Image"] = image;


                return View();
            }
            else
            {
                Session["Action"] = "AddAdress";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }
           
        }


        public ActionResult AddInfo(Adrese address)
        {
            if (Session["Perdorues"] != null)
            {
                TempData["adresa"] = address;

                KategoriProneDbClient kategoriDbClient = new KategoriProneDbClient();
                try
                {
                    ViewBag.Categories = kategoriDbClient.GetCategories();
                    ViewBag.Flag = true;
                }
                catch (SqlException ex)
                {
                    ViewBag.Flag = false;
                    ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                }

            }
            else
            {
                Session["Action"] = "AddInfo";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }
            
            return View();
        }


        public ActionResult AddProne(ProneInfo info)
        {
            if (Session["Perdorues"] != null)
            {
                TempData["info"] = info;
            }
            else
            {
                Session["Action"] = "AddProne";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }
            return View();
        }


        public ActionResult CompleteProneRegistration(ProneComponent prone)
        {
            if (Session["Perdorues"] != null)
            {

                TempData["prone"] = prone;
                try
                {
                    try
                    {
                        Photo image = (Photo)TempData["Image"];
                        string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                        string extension = Path.GetExtension(image.ImageFile.FileName);
                        fileName = fileName + extension;
                        image.profilePicPath = "~/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        image.ImageFile.SaveAs(fileName);

                        Konsumator konsumator = (Konsumator)Session["Perdorues"];
                        ProneRegistrationDbClient proneRegDbClient = new ProneRegistrationDbClient();
                        proneRegDbClient.Insert((PozicionGjeografik)TempData["pozicioni"], (Adrese)TempData["adresa"], (ProneInfo)TempData["info"], (ProneComponent)TempData["prone"], konsumator.IdKonsumator, image);
                        ViewBag.ErrorMessage = "Publikimi u krye me sukses!";

                    }
                    catch (NullReferenceException ex)
                    {
                        ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                    }

                   
                }
                catch (SqlException ex)
                {
                    ViewBag.ErrorMessage = "Publikimi deshtoi! " + ex.Message;
                }
            }
            else
            {
                Session["Action"] = "CompleteProneRegistration";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddProneData()
        {
            if (Session["Perdorues"]!= null)
            {
                ShtetDbClient shtetClient = new ShtetDbClient();
                QytetDbClient qytetClient = new QytetDbClient();

                try
                {
                    ViewBag.Countries = shtetClient.GetCountries();
                    ViewBag.Cities = qytetClient.GetCities();
                    ViewBag.Flag = true;
                }
                catch (SqlException ex)
                {
                    ViewBag.Flag = false;
                    ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                }

                KategoriProneDbClient kategoriDbClient = new KategoriProneDbClient();
                try
                {
                    ViewBag.Categories = kategoriDbClient.GetCategories();
                    ViewBag.Flag = true;
                }
                catch (SqlException ex)
                {
                    ViewBag.Flag = false;
                    ViewBag.ErrorMessage = "Something went wrong! " + ex.Message;
                }
            }
            else
            {
                Session["Action"] = "AddProneData";
                Session["Controller"] = "Publish";
                return RedirectToAction("NotLogged", "Login");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult PostData(FormCollection collection)
        {
            double latitude = Convert.ToDouble(collection["latitude"]);
            double logitude = Convert.ToDouble(collection["logitude"]);
            Debug.WriteLine(latitude + "  " + logitude);
            PozicionGjeografik pozicion = new PozicionGjeografik(latitude,logitude);
            Photo image = new Photo("Name","Here");

            String rrugeEmer = collection["rrugeEmerTxt"];
            int nderteseNumer = Convert.ToInt32(collection["nderteseNumeTxt"]);
            int shkalle = Convert.ToInt32(collection["shkalleNumerTxt"]);
            int apartament = Convert.ToInt32(collection["apartamentNumerTxt"]);
            int shtet = Convert.ToInt32(collection["shtetSelect"]);
            int qytet = Convert.ToInt32(collection["qytetSelect"]);
            int zipCode = Convert.ToInt32(collection["zipCodeTxt"]);

            Adrese adrese = new Adrese(rrugeEmer, nderteseNumer, shkalle, apartament, shtet, qytet, zipCode);

            double rating = Convert.ToDouble(collection["ratingTxt"]);
            int select = Convert.ToInt32(collection["selectCategory"]);

            ProneInfo proneInfo = new ProneInfo(rating, select);

            String proneTitull = collection["proneTitullTxt"];
            double sip = Convert.ToDouble(collection["proneSiperfaqeTxt"]);
            int nrDh = Convert.ToInt32(collection["proneNumerDhomashTxt"]);
            int nrB = Convert.ToInt32(collection["proneNumerBanjoTxt"]);
            int eLire = Convert.ToInt32(collection["elireSelect"]);
            double cmimPerMuaj = Convert.ToDouble(collection["cmimPerMuajTxt"]);

            ProneComponent prone = new ProneComponent(proneTitull, sip, nrDh, nrB, eLire,cmimPerMuaj);
            
            try
            {
                Konsumator konsumator = (Konsumator)Session["Perdorues"];
                ProneRegistrationDbClient proneRegDbClient = new ProneRegistrationDbClient();
                proneRegDbClient.Insert(pozicion,adrese,proneInfo,prone,konsumator.IdKonsumator, image);
                ViewBag.ErrorMessage = "Publikimi u krye me sukses!";
                return Json(new { status = "success", message = ViewBag.ErrorMessage });
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = "Publikimi deshtoi! " + ex.Message;
                return Json(new { status = "error", message = ViewBag.ErrorMessage });
            }
            

            

            
        }
    }
}