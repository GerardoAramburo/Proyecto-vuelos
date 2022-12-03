using Proyecto_vuelos.Entidades;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_vuelos.Controllers
{
    public class BoletoController : Controller
    {
        // GET: Boleto
        public ActionResult Index()
        {
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            List<Boleto> boletos = Boleto.GetAll();

            return View(boletos);
        }

        // GET: Boleto/Details/5
        public ActionResult Detalles(int id)
        {
            Boleto boleto = Boleto.GetById(id);
            return View(boleto);
        }

        // GET: Boleto/Registro
        public ActionResult Registro(int id)
        {
            if (Session.Count == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (id > 0) //Editar
            {
                return View();
            
            } 
            else // Crear nuevo
            {
                dynamic model = new ExpandoObject();
                model.Pasajeros = Pasajero.GetAll();
                model.Vuelos = Vuelo.GetAll();
                return View(model);
            }

        }

        // POST: Boleto/Guardar
        [HttpPost]
        public ActionResult Guardar(FormCollection collection)
        {
            try
            {

                Boleto boleto = new Boleto();
                boleto.Id = 0;
                boleto.Pasajero = Pasajero.GetById(int.Parse(collection["pasajero_id"]));

                boleto.Vuelo = Vuelo.GetById(int.Parse(collection["vuelo_id"]));

                Boleto.Guardar(boleto);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Eliminar(int id)
        {
            Boleto.Eliminar(id);
            return RedirectToAction("Index", "Boleto");
        }
    }
}
