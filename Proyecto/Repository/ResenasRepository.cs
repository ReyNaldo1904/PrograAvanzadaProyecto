using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Proyecto.Models;
/*
      * Autor: greg
      * 
      * 
      * 
      * */
namespace Proyecto.Repository
{
    public class ResenasRepository : IResenasRepository
    {
        private readonly ApplicationDbContext _context;
        public ResenasRepository() { 
            _context = new ApplicationDbContext();
        }
        public void Add(int productoId, string comentario, int calificacion, string usuarioId)
        {
            var nuevaResena = new Resenas
            {
                ProductoId = productoId,
                UsuarioId = usuarioId, // Obtiene el usuario actual
                Comentario = comentario,
                Calificacion = calificacion,
                Fecha = DateTime.Now
            };

            _context.Resenas.Add(nuevaResena);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            Resenas resenas = _context.Resenas.Find(id);
            _context.Resenas.Remove(resenas);
            _context.SaveChanges();
        }

        public Resenas GetById(int? id)
        {
            Resenas resenas = _context.Resenas.Find(id);
            return resenas;
        }

        public IEnumerable<Resenas> GetByProducto(int idProducto)
        {
            var resenas = _context.Resenas.AsQueryable();
            resenas = resenas.Where(p => p.ProductoId == idProducto);
            return resenas.ToList();
        }

        public IEnumerable<Resenas> GetByUser(string user)
        {
            var resenas = _context.Resenas.AsQueryable();
            resenas = resenas.Where(p => p.UsuarioId == user);
            return resenas.ToList();
        }

        public IEnumerable<Resenas> GetResenas()
        {
            return _context.Resenas.ToList();
        }

        public void Update(Resenas resenas)
        {
            _context.Entry(resenas).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}