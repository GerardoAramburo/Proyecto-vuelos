using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_vuelos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}