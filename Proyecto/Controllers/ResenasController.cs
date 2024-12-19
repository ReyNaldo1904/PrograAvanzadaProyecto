using System;
using System.Linq;
using System.Web.Mvc;
using Proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    [Authorize]
    public class ResenasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ResenasService _resenasService;

        public ResenasController()
        {
            _resenasService = new ResenasService();
        }

        // POST: Resenas/Create
        /*[HttpPost]
        
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
        }*/

        public ActionResult Crear(int productoId, string comentario, int calificacion)
        {
            try
            {
                var UsuarioId = User.Identity.Name;
                
                _resenasService.Add(productoId, comentario, calificacion,UsuarioId);
                return RedirectToAction("Details", "Catalogo", new { id = productoId });
            }
            catch
            {
                return RedirectToAction("Index", "Catalogo");

            }
        }
        /*
         * Autor: Luis David Miranda
         * Descripcion: muestra todas las reseñas
         * 
         * 
         * */
        public ActionResult MostrarResenas()
        {
            try
            {

                return View(_resenasService.GetResenas());
            }
            catch
            {
                return RedirectToAction("Index", "Catalogo");

            }
        }

    }
}