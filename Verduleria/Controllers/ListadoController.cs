using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Verduleria.Models;

namespace Verduleria.Controllers
{
    public class ListadoController : Controller
    {
        // GET: Listado
        public ActionResult Index()
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            
            return View(ma.RecuperarTodos());
        }
    }
}