using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Services
{
    internal interface IPedidoService
    {
        IEnumerable<Pedido> GetPedidos();
        Pedido GetById(int? id);

        IEnumerable<Pedido> GetByUser(string user);
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(int id);
    }
}
