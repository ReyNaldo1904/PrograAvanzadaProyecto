using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetProductos();
        Producto GetById(int? id);
        void CreateProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int id);
    }
}
