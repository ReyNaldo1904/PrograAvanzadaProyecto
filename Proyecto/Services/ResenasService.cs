using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Repository;

namespace Proyecto.Services
{
    public class ResenasService : IResenasService
    {
        private readonly ResenasRepository _repository;

        public ResenasService()
        {
            _repository = new ResenasRepository();
        }
        public void Add(int productoId, string comentario, int calificacion, string usuarioId)
        {
            _repository.Add(productoId, comentario, calificacion, usuarioId);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Resenas GetById(int? id)
        {
            if(id == null) return null;
            return _repository.GetById(id);
        }

        public IEnumerable<Resenas> GetByProducto(int idProducto)
        {
            return _repository.GetByProducto(idProducto);
        }

        public IEnumerable<Resenas> GetByUser(string user)
        {
            return _repository.GetByUser(user);
        }

        public IEnumerable<Resenas> GetResenas()
        {
            return _repository.GetResenas();
        }

        public void Update(Resenas resenas)
        {
             _repository.Update(resenas);
        }
    }
}