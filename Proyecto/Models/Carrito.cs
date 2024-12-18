using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/*
 * Codigo hecho por Luis
 * 
 * 
 * */
namespace Proyecto.Models
{
    public class Carrito
    {
        [Key]
        public int CarritoId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public virtual Producto Producto { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; } 
        
        public decimal Total { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

    }
}