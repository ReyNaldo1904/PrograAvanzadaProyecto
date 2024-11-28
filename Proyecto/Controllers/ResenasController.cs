using System;
using System.Linq;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Authorize]
    public class ResenasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Resenas/Create
        [HttpPost]
        public ActionResult Crear(int productoId, string comentario, int calificacion)
        {
            try
            {
                var nuevaResena = new Resenas
                {
                    ProductoId = productoId,
                    UsuarioId = User.Identity.Name, // Obtiene el usuario actual
                    Comentario = comentario,
                    Calificacion = calificacion,
                    Fecha = DateTime.Now
                };

                db.Resenas.Add(nuevaResena);
                db.SaveChanges();

                return RedirectToAction("Details", "Catalogo", new { id = productoId });
            }
            catch
            {
                return RedirectToAction("Index", "Catalogo");

            }
        }
    }
}