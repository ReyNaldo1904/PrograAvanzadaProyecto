using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/*
 * Codigo hecho por Luis
 * 
 * 
 * */
namespace Proyecto.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CarritoId { get; set; }
        public virtual Carrito Carrito { get; set; }
        //se pone la fecha actual del equipo 
        public DateTime FechaPedido { get; set; } = DateTime.Now;

        public decimal TotalPedido { get; set; }

    }
}