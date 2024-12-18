using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Proyecto.Controllers;
using Proyecto.Models;

namespace Proyecto.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository() {

            _context = new ApplicationDbContext();
        }
        public void Add(Producto product)
        {
            _context.Productos.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Producto producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }

        public Producto GetById(int? id)
        {
            Producto producto = _context.Productos.Find(id);
            return producto;
        }

        public IEnumerable<Producto> GetProductos()
        {
            return _context.Productos.ToList();
        }

        public void Update(Producto product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}