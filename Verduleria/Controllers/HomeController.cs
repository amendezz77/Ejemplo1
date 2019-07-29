using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Verduleria.Models;

namespace Verduleria.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();

            return View(ma.RecuperarTodos());

            //return View();
        }
        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"]),
                Descripcion = collection["descripcion"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Alta(art);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(cod);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int cod)
        {
            Console.WriteLine("Modificación antes de instanciar");
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(cod);
            Console.WriteLine("Modificación comienzo \n\n: {0} - {1}", art.Codigo, art.Descripcion);
            return View(art);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"].ToString()),
                Descripcion = collection["descripcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };

            ma.Modificar(art);

            return RedirectToAction("Index");
        }



    }
}

