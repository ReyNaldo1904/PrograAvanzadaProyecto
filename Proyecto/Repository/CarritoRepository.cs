using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Models;
using System.Data.Entity;
using System.CodeDom;

namespace Proyecto.Repository
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly ApplicationDbContext _context;

        public CarritoRepository() {
            _context = new ApplicationDbContext();
        }
        /*
        * Autor: Luis David Miranda
        * Descripcion: añadir un carrito con un producto que el usuario eligio
        * Valida que la cantidad en el carrito sea menor al inventario
        * 
        * */
        public void Add(Carrito carrito)
        {
            if(carrito.Cantidad <= carrito.Producto.Inventario)
            {
                _context.Carritos.Add(carrito);
                _context.SaveChanges();
            }
           
            
        }
        /*
        * Autor: Luis David Miranda
        * Descripcion: elimina un carrito
        * 
        * 
        * */
        public void Delete(int id)
        {
            Carrito carrito = _context.Carritos.Find(id);
            _context.Carritos.Remove(carrito);
            _context.SaveChanges();
        }

        /*
        * Autor: Luis David Miranda
        * Descripcion: elimina un carrito
        * 
        * 
        * */
        public Carrito GetById(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return _context.Carritos.Find(id);
        }
        /*
        * Autor: Luis David Miranda
        * Descripcion: devuelve un carrito por usuario
        * 
        * 
        * */
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
            if (carrito.Cantidad <= carrito.Producto.Inventario)
            {
                _context.Entry(carrito).State = EntityState.Modified;
                _context.SaveChanges();
            }
               
        }
    }
}