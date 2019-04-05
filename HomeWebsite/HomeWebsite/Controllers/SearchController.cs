using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWebsite.Models.Entities;
using HomeWebsite.Models.Clients;
using System.Data.SqlClient;
using HomeWebsite.Models;

namespace HomeWebsite.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult SearchByCityResult(Search search)
        {
            List<Prone> list = new List<Prone>();
            try
            {
                SearchOperations ops = new SearchOperations();
                
                if (ops.HasRecordsByCity(search))
                {
                    list = ops.SearchByCity(search);
                    ViewBag.Prones = list;
                    ViewBag.Flag = true;
                    
                }
                else
                {
                    ViewBag.ErrorMessage = "Nothing in the database!";
                    ViewBag.Flag = false;
                }
                
            }
            catch(SqlException ex)
            {
                ViewBag.ErrorMessage = "Nothing in the database!";
                ViewBag.Flag = false;
            }
            return View();
        }
    }
}