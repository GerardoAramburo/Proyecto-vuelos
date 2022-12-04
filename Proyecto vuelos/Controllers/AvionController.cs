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
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            List<Avion> aviones = Avion.GetAll();
            return View(aviones);
        }

        public ActionResult Registro(int id)
        {
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            Avion avion = Avion.GetById(id);
            return View(avion);
        }

        public ActionResult Guardar(int id, string placa, string nombre)
        {
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            Avion.Guardar(id, placa, nombre);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            Avion.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}