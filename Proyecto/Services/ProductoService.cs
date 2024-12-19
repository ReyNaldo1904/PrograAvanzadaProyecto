using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using Proyecto.Repository;

namespace Proyecto.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ProductoRepository _repository;
        public ProductoService() { 
            _repository = new ProductoRepository();
        
        }
        public void CreateProducto(Producto producto)
        {
            /*
         * Autor: Luis David Miranda
         * Descripcion: añadir producto
         * 
         * 
         * */
            _repository.Add(producto);
        }

        public void DeleteProducto(int id)
        {
            /*
         * Autor: Luis David Miranda
         * Descripcion: eliminar
         * 
         * 
         * */
            _repository.Delete(id);
        }

        public Producto GetById(int? id)
        {
            /*
          * Autor: Luis David Miranda
          * Descripcion:obtener producto por id
          * 
          * 
          * */
            return _repository.GetById(id);
        }

        public IEnumerable<Producto> GetProductos()
        {
            /*
         * Autor: Luis David Miranda
         * Descripcion: devuelve una lista de productos
         * 
         * 
         * */
            return _repository.GetProductos();
        }

        public IEnumerable<Producto> GetProductos(bool estado)
        {
            return _repository.GetProductos(estado);
        }

        public void UpdateProducto(Producto producto)
        {
            /*
         * Autor: Luis David Miranda
         * Descripcion: actualiza un producto 
         * 
         * 
         * */
            _repository.Update(producto);
        }
    }
}