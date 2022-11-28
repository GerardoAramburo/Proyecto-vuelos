using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_vuelos.Views.Logout
{
    public class LogoutController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}