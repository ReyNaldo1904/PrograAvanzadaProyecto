using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Models;

namespace Proyecto.Repository
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetProductos();
        IEnumerable<Producto> GetProductos(Boolean estado);
        Producto GetById(int? id);
        void Add(Producto product);
        void Update(Producto product);
        void Delete(int id);
    }
}