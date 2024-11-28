using System.Linq;
using System.Web.Mvc;
using Proyecto.Models; 

namespace Proyecto.Controllers
{
    public class CatalogoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catalogo
        public ActionResult Index()
        {
            var productos = db.Productos.ToList(); 
            return View(productos); 
        }
    }
}
