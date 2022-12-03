using Proyecto_vuelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_vuelos.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: Pasajero
        public ActionResult Index()
        {
            List<Pasajero> pasajeros = Pasajero.GetAll();
            return View(pasajeros);
        }

        public ActionResult Registro(int id)
        {
            Pasajero pasajero = Pasajero.GetById(id);
            return View(pasajero);
        }

        public ActionResult Guardar(int id, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento)
        {
            Pasajero.Guardar(id, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Pasajero.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}