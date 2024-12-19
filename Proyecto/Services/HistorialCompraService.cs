using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Models;
using Proyecto.Repository;

namespace Proyecto.Services
{
    public class HistorialCompraService : IHistorialCompraService
    {
        private readonly HistorialCompraRepository _repository;
        public HistorialCompraService()
        {
            _repository = new HistorialCompraRepository();
        }
        public void Add(int productoId, int cantidad, string usuarioId)
        {
            _repository.Add(productoId,cantidad, usuarioId);
        }

        public IEnumerable<HistorialPedido> GetHistorialPedido(string usuarioId)
        {
            return _repository.GetHistorialPedido(usuarioId);
        }
    }
}