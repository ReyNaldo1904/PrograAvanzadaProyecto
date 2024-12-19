using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proyecto.Models;
using Proyecto.Services;

public class HistorialComprasController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    private readonly HistorialCompraService _historialCompraService;
    public HistorialComprasController()
    {
        _historialCompraService = new HistorialCompraService();
    }
    [Authorize] // Solo usuarios autenticados
    public ActionResult Index()
    {
        string userId = User.Identity.GetUserId();
       var historial = _historialCompraService.GetHistorialPedido(userId);
        
        return View(historial);
    }

    // Método para registrar una nueva compra
    [Authorize]
    [HttpPost]
    public ActionResult RegistrarCompra(int productoId, int cantidad)
    {
        try
        {
            string usuarioId = User.Identity.GetUserId();
            _historialCompraService.Add(productoId, cantidad, usuarioId);

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }
}