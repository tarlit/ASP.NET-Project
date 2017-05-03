using SmallHotels.App_GlobalResources;
using SmallHotels.Auth.Models;
using SmallHotels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmallHotels.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // samo za demoto 
            //SmallHotelsEfDbContext dbContext = new SmallHotelsEfDbContext();
            //var books = dbContext.Books.ToList();
            //var categories = dbContext.Categories.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = GlobalResources.ViewAboutMessage;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}