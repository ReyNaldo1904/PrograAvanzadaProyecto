using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Models;
using Proyecto.Repository;

namespace Proyecto.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _repository;

        public PedidoService()
        {
            _repository = new PedidoRepository();
        }
        public void Add(Pedido pedido)
        {
            _repository.Add(pedido);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Pedido GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Pedido> GetByUser(string user)
        {
            return _repository.GetByUser(user);
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            return _repository.GetPedidos();
        }

        public void Update(Pedido pedido)
        {
            _repository.Update(pedido);
        }
    }
}