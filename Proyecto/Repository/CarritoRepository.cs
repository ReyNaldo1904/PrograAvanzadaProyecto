using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Models;
using System.Data.Entity;

namespace Proyecto.Repository
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly ApplicationDbContext _context;

        public CarritoRepository() {
            _context = new ApplicationDbContext();
        }
        public void Add(Carrito carrito)
        {
            _context.Carritos.Add(carrito);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Carrito carrito = _context.Carritos.Find(id);
            _context.Carritos.Remove(carrito);
            _context.SaveChanges();
        }

        public Carrito GetById(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return _context.Carritos.Find(id);
        }

        public Carrito GetByUser(string id)
        {
            return _context.Carritos.Find(id);
        }

        public IEnumerable<Carrito> GetCarrito()
        {
            var carritos = _context.Carritos.Include(p => p.Producto);
            return carritos.ToList();
        }

        public void Update(Carrito carrito)
        {
            _context.Entry(carrito).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}