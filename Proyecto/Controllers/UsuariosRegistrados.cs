using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class UsuariosRegistrados : Controller
    {
        // GET: UsuariosRegistrados
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuariosRegistrados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosRegistrados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosRegistrados/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosRegistrados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosRegistrados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosRegistrados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosRegistrados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
