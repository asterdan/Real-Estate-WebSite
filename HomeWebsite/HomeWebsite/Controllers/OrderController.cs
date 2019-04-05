using HomeWebsite.Models.Clients;
using HomeWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWebsite.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult OrderProcess(FormCollection collection)
        {
            ViewBag.ErrorMessage = "Waiting...";
            if (Session["Perdorues"] != null)
            {
                Konsumator perdorues = (Konsumator)Session["Perdorues"];
                int idBleres = perdorues.IdKonsumator;
                int idShites = Convert.ToInt32(collection["idShites"]);
                ViewBag.UserNameShites = collection["userNameShites"];
                ViewBag.UserNameBleres = perdorues.UserName;
                double pricePerMonth = Convert.ToDouble(collection["pricePerMonth"]);
                double totali = Convert.ToDouble(collection["totali"]);
                int sasiaMuajve = Convert.ToInt32(collection["sasiaTxt"]);
                int idProne = Convert.ToInt32(collection["proneId"]);
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now.AddMonths(sasiaMuajve);
                String description = perdorues.UserName + " porositi shtepine me id : " + idProne + " nga pronari : " + idShites +  " nga data : " + startDate + " deri me  + " + endDate + ".";
                ProneComponent comp = new ProneComponent(idProne);
                Rental rent = new Rental(idBleres, idShites, startDate);
                RentalDetails details = new RentalDetails(pricePerMonth, idProne, sasiaMuajve, startDate, endDate, description, totali);
                Order order = new Order(comp,rent,details);
                OrderClient orderClient = new OrderClient();

                if (idBleres != idShites)
                {
                    try
                    {
                        orderClient.InsertOrder(order);
                        ViewBag.ErrorMessage = "Order proccessed successfully!";
                        return Json(new { data =  new { status = "success", message = (String)ViewBag.ErrorMessage }});
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Something went wrong! " + ex.Message + " Stacktrace: " + ex.StackTrace;
                        return Json(new { data = new { status = "failure", message = (String)ViewBag.ErrorMessage } });
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "The property is yours you cannot order it!";
                    return Json(new { data = new  { status = "failure", message = (String)ViewBag.ErrorMessage } });
                }
                
            }
            else
            {
                Session["Action"] = "OrderProcess";
                Session["Controller"] = "Order";
                return RedirectToAction("LoginForm", "Login");
            }
           
        }
    }
}