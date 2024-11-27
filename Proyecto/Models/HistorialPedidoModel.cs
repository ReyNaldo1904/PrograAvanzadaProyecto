using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class HistorialPedido
    {
        public int Id { get; set; } // Clave primaria
        public string UsuarioId { get; set; } // Clave foranea a AspNetUsers.Id
        public virtual ApplicationUser Usuario { get; set; } // Relacion con los usuarios
        public int ProductoId { get; set; } // Clave foranea a Productos.Id
        public virtual Producto Producto { get; set; } // Relacion con los productos
        public DateTime Fecha { get; set; } // Fecha del pedido
        public int Cantidad { get; set; } // Cantidad comprada
        public decimal PrecioUnitario { get; set; } // Nuevo campo
        
        // Propiedad calculada
        public decimal Total
        {
            get { return Cantidad * PrecioUnitario; }
        }
    }

}