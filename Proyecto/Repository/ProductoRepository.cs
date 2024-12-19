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
            /*
      * Autor: Luis David Miranda
      * Descripcion:Elimina un producto de forma logica
      * 
      * 
      * */
            Producto producto = _context.Productos.Find(id);
            producto.Estado = false;
            _context.Entry(producto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Producto GetById(int? id)
        {
            Producto producto = _context.Productos.Find(id);
            return producto;
        }

        public IEnumerable<Producto> GetProductos()
        {
                 /*
      * Autor: Luis David Miranda
      * Descripcion:Muestra todos los productos
      * 
      * 
      * */
            
            return _context.Productos.ToList();
        }

        public IEnumerable<Producto> GetProductos(bool estado)
        {
            /*
      * Autor: Luis David Miranda
      * Descripcion:Muestra unicamente los productos dependiendo del estado
      * 
      * 
      * */
            
            var producto = _context.Productos.AsQueryable();
            producto = producto.Where(p => p.Estado == estado);
            return producto.ToList();
        }

        public void Update(Producto product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}