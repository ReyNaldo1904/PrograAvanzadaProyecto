using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Repository
{
    internal interface IPedidoRepository
    {
        IEnumerable<Pedido> GetPedidos();
        Pedido GetById(int? id);

        IEnumerable<Pedido> GetByUser(String user);
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(int id);
    }
}
