using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Controllers;
using System.Web.Mvc;
using Proyecto.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.Ajax.Utilities;
using System.Web.Helpers;

namespace Proyecto.Repository
{
    public class HistorialCompraRepository : IHistorialComprasRepository
    {
        private readonly ApplicationDbContext _context;
        public HistorialCompraRepository()
        {
            _context = new ApplicationDbContext();
        }
        public void Add(int productoId, int cantidad, string usuarioId)
        {
            var producto = _context.Productos.Find(productoId);

            if (producto != null || producto.Inventario > cantidad) {
                var pedido = new HistorialPedido
                {
                    UsuarioId = usuarioId,
                    ProductoId = productoId,
                    Cantidad = cantidad,
                    Fecha = DateTime.Now,
                    PrecioUnitario = producto.Precio
                };

                producto.Inventario -= cantidad;

                _context.HistorialPedidos.Add(pedido);
                _context.SaveChanges();
            }
            
        }

        public IEnumerable<HistorialPedido> GetHistorialPedido(string usuarioId)
        {
            string userId = usuarioId;
            var historial = _context.HistorialPedidos
                .Include(h => h.Producto)
                .Where(h => h.UsuarioId == userId)
                .OrderByDescending(h => h.Fecha)
                .ToList();
            return historial;
        }
    }
    
}