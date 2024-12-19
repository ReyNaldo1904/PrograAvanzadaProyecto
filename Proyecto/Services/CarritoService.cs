using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Models;
using Proyecto.Repository;

namespace Proyecto.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly CarritoRepository _repository;
        public CarritoService() {
            _repository = new CarritoRepository();
        }
        public void CreateCarrito(Carrito carrito)
        {
            _repository.Add(carrito);
        }

        public void DeleteCarrito(int id)
        {
            _repository.Delete(id);
        }

        public Carrito GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return _repository.GetById(id);
        }

        public Carrito GetByUser(string id)
        {
            if (id == null)
            {
                return null;
            }
            return _repository.GetByUser(id);
        }

        public IEnumerable<Carrito> GetCarrito()
        {
            return _repository.GetCarrito().ToList();
        }

        public void UpdateCarrito(Carrito carrito)
        {
             _repository.Update(carrito);
        }
    }
}