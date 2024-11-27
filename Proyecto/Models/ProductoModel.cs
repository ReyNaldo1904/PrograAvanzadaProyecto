using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Producto
    {
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; } // Nombre del producto
        public decimal Precio { get; set; } // Precio del producto
        public int Inventario { get; set; } // Cantidad en inventario
        public bool Estado { get; set; } // Activo o inactivo
        public string Imagenes { get; set; } // Almacena rutas de imagenes separadas por comas
        public string Reviews { get; set; } // Texto plano o JSON con las reviews
    }

}