using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Proyecto.Models;

namespace Proyecto.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository() { 
            _context = new ApplicationDbContext();
        }
        public void Add(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Pedido pedido = _context.Pedidos.Find(id);
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

        public Pedido GetById(int? id)
        {
            if (id == null) return null;
            return _context.Pedidos.Find(id);
        }

        public IEnumerable<Pedido> GetByUser(string user)
        {
           if(user == null) return null;
           var Pedidos = _context.Pedidos.AsQueryable();
            Pedidos = Pedidos.Where(u => u.Carrito.Usuario.Id == user);
            return _context.Pedidos.ToList();
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            var pedidos = _context.Pedidos.Include(p => p.Carrito);
            return pedidos.ToList();
        }

        public void Update(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}