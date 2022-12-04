using Proyecto_vuelos.Entidades;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_vuelos.Controllers
{
    public class VueloController : Controller
    {
        // GET: Vuelo
        public ActionResult Index()
        {
            List<Vuelo> vuelos = Vuelo.GetAll();
            return View(vuelos);
        }

        public ActionResult Registro(int id)
        {
            dynamic model = new ExpandoObject();
            model.Vuelo = Vuelo.GetById(id);
            model.aviones = Avion.GetAll();
            return View(model);
        }

        public ActionResult Guardar(int id, string origen, string destino, int idAvion, string capacidad, string fecha)
        {
            Vuelo.Guardar(id, origen, destino, idAvion, capacidad, DateTime.Parse(fecha));
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Vuelo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}