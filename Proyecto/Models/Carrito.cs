using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Proyecto.Models
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; } // primary key

        public DateTime FechaCreacion { get; set; } = DateTime.Now; // fecha de la creacion del carrito
        [Required]
        public string IdUsuario { get; set; } //relacionar el usuario con el carrito
        public virtual ApplicationUser Usuario { get; set; }
    }
}