using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    public class PedidoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly PedidoService _pedidoService;

        public PedidoController()
        {
            _pedidoService = new PedidoService();
        }

        // GET: Pedido
        public ActionResult Index()
        {
            /*
         * Autor: Luis David Miranda
         * Descripcion: obtener todos los pedidos
         * 
         * 
         * */
            return View(_pedidoService.GetPedidos());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = _pedidoService.GetById(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }
        //Muestra una vista unicamente para un usuario especifico
        public ActionResult DetailsForUser(string user)
        {
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*
         * Autor: Luis David Miranda
         * Descripcion: se obtiene la lista de pedidos con un mismo idUsuario del carrito
         * 
         * 
         * */
            IEnumerable<Pedido> pedido = _pedidoService.GetByUser(user);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.CarritoId = new SelectList(db.Carritos, "CarritoId", "CarritoId");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarritoId,FechaPedido,TotalPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _pedidoService.Add(pedido);
                return RedirectToAction("Index");
            }

            ViewBag.CarritoId = new SelectList(db.Carritos, "CarritoId", "CarritoId", pedido.CarritoId);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = _pedidoService.GetById(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarritoId = new SelectList(db.Carritos, "CarritoId", "CarritoId", pedido.CarritoId);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarritoId,FechaPedido,TotalPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _pedidoService.Update(pedido);
                return RedirectToAction("Index");
            }
            ViewBag.CarritoId = new SelectList(db.Carritos, "CarritoId", "CarritoId", pedido.CarritoId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = _pedidoService.GetById(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _pedidoService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
