using Proyecto_vuelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_vuelos.Controllers
{
    public class AvionController : Controller
    {
        // GET: Avion
        public ActionResult Index()
        {
            List<Avion> aviones = Avion.GetAll();
            return View(aviones);
        }
    }
}