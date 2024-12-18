using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Repository
{
    internal interface ICarrito
    {
        IEnumerable<Carrito> GetCarrito(string id);
        Carrito GetByUser(string id);
        void Add(Carrito carrito);
        void Update(Carrito carrito);
        void Delete(int id);
    }
}
