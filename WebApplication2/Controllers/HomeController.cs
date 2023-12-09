using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var shoppingCart = Session["ShoppingCart"] as ShoppingCart;
            if (shoppingCart != null)
            {
                foreach (var itemadded in shoppingCart.Items)
                {

                    var itemName = itemadded.id_Movie;
                  
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}