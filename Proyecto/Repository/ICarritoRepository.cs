using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Repository
{
    internal interface ICarritoRepository
    {
        IEnumerable<Carrito> GetCarrito();
        Carrito GetByUser(string id);

        Carrito GetById(int? id);
        void Add(Carrito carrito);
        void Update(Carrito carrito);
        void Delete(int id);
    }
}
