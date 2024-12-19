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
            _repository.Add(producto);
        }

        public void DeleteProducto(int id)
        {
            _repository.Delete(id);
        }

        public Producto GetById(int? id)
        {
            if (id == null) {
                return null;
            } 
            return _repository.GetById(id);
        }

        public IEnumerable<Producto> GetProductos()
        {
            return _repository.GetProductos();
        }

        public void UpdateProducto(Producto producto)
        {
            _repository.Update(producto);
        }
    }
}