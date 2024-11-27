using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proyecto.Models;

public class HistorialComprasController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    [Authorize] // Solo usuarios autenticados
    public ActionResult Index()
    {
        string userId = User.Identity.GetUserId();
        var historial = db.HistorialPedidos
            .Include(h => h.Producto)
            .Where(h => h.UsuarioId == userId)
            .OrderByDescending(h => h.Fecha)
            .ToList();
        
        return View(historial);
    }

    // Método para registrar una nueva compra
    [Authorize]
    [HttpPost]
    public ActionResult RegistrarCompra(int productoId, int cantidad)
    {
        try
        {
            var producto = db.Productos.Find(productoId);
            if (producto == null || producto.Inventario < cantidad)
            {
                return Json(new { success = false, message = "Producto no disponible" });
            }

            var pedido = new HistorialPedido
            {
                UsuarioId = User.Identity.GetUserId(),
                ProductoId = productoId,
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                PrecioUnitario = producto.Precio
            };

            producto.Inventario -= cantidad;
            
            db.HistorialPedidos.Add(pedido);
            db.SaveChanges();

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }
}