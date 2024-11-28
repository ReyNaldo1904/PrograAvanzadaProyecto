using Proyecto.Models;
using System;

public class Resenas
{
    public int Id { get; set; } // Clave primaria
    public int ProductoId { get; set; } // Relación con el producto
    public string UsuarioId { get; set; } // Relación con el usuario
    public string Comentario { get; set; } // Contenido de la reseña
    public int Calificacion { get; set; } // Calificación (1-5 estrellas)
    public DateTime Fecha { get; set; } // Fecha de la reseña

    // Navegación
    public virtual Producto Producto { get; set; }
}