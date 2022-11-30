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

        public ActionResult Registro(int id)
        {
            Avion avion = Avion.GetById(id);
            return View(avion);
        }

        public ActionResult Guardar(int id, string nombre, string placa)
        {
            Avion.Guardar(id, nombre, placa);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Avion.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}