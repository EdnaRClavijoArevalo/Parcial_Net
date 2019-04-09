using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dataAccess.Models;
using dataAccess;

namespace colegio7.Controllers
{
    public class BarriosController : Controller
    {
        private ColegioEntities db = new ColegioEntities();

        // GET: /Barrios/
        public ActionResult Index()
        {
            return View(db.Barrios.ToList());
        }

        // GET: /Barrios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrios barrios = db.Barrios.Find(id);
            if (barrios == null)
            {
                return HttpNotFound();
            }
            return View(barrios);
        }

        // GET: /Barrios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Barrios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idBarrio,nombreBarrio")] Barrios barrios)
        {
            if (ModelState.IsValid)
            {
                db.Barrios.Add(barrios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barrios);
        }

        // GET: /Barrios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrios barrios = db.Barrios.Find(id);
            if (barrios == null)
            {
                return HttpNotFound();
            }
            return View(barrios);
        }

        // POST: /Barrios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idBarrio,nombreBarrio")] Barrios barrios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barrios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barrios);
        }

        // GET: /Barrios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrios barrios = db.Barrios.Find(id);
            if (barrios == null)
            {
                return HttpNotFound();
            }
            return View(barrios);
        }

        // POST: /Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrios barrios = db.Barrios.Find(id);
            db.Barrios.Remove(barrios);
            db.SaveChanges();
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
