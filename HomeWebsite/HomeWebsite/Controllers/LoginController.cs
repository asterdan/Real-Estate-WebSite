using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;


namespace HomeWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginForm()
        {
            return View();
        }

        public ActionResult LoginCompletition(Konsumator  konsumator)
        {
            bool flag = false;
            Konsumator kons = new Konsumator();
            KonsumatorDbClient konsumatorDbClient = new KonsumatorDbClient();
            try
            {
                flag = konsumatorDbClient.CheckLogin(konsumator);
                if (flag == true)
                {
                    kons = konsumatorDbClient.GetLoginSession(konsumator);
                    Session["Perdorues"] = kons;
                    Konsumator konsumues = (Konsumator)Session["Perdorues"];
                    ViewBag.ErrorMessage = "Login u krye me sukses! " + "Welcome, " + konsumues.UserName;
                    if (Session["Action"] != null && Session["Controller"] != null)
                    {
                        return RedirectToAction((String)Session["Action"], (String)Session["Controller"]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Login deshtoi! ";
                }
                
            }
            catch(SqlException ex)
            {
                ViewBag.ErrorMessage = "Something went wrong ! " + ex.StackTrace;
            }
            return View();
           
        }


        public ActionResult NotLogged()
        {
           
            return View();
        }
    }
}