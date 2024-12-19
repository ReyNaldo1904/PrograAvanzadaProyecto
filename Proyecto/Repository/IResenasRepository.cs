﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Repository
{
    internal interface IResenasRepository
    {
        

        IEnumerable<Resenas> GetResenas();
        Resenas GetById(int? id);

        IEnumerable<Resenas> GetByUser(String user);

        IEnumerable<Resenas> GetByProducto(int idProducto);
        void Add(int productoId, string comentario, int calificacion, string usuarioId);
        void Update(Resenas resenas);
        void Delete(int id);
    }
}