using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface ICarritoService
    {
        IEnumerable<Carrito> GetCarrito();
        Carrito GetByUser(string id);

        Carrito GetById(int? id);
        void CreateCarrito(Carrito carrito);
        void UpdateCarrito(Carrito carrito);
        void DeleteCarrito(int id);
    }
}
