using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductoService _productoService;

        public HomeController()
        {
            _productoService = new ProductoService();
        }
        public ActionResult Index()
        {
            var estado = true;
            return View(_productoService.GetProductos(estado));
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}