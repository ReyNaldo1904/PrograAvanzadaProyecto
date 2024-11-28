using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CarritoId { get; set; }
        public virtual Carrito Carrito { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public virtual Producto Producto { get; set; }
        [Required]
        public int Cantidad { get; set; } 

    }
}