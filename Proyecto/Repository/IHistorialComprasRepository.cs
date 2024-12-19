using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Repository
{
    internal interface IHistorialComprasRepository
    {
        IEnumerable<HistorialPedido> GetHistorialPedido(string usuarioId);
        
        void Add(int productoId, int cantidad, string usuarioId);
        
    }
}
