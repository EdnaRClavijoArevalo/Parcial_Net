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
    public class cursosController : Controller
    {
        private ColegioEntities db = new ColegioEntities();
        [Authorize(Roles = "Admin,Consultas")]
        // GET: /cursos/
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.Colegio);
            return View(cursos.ToList());
        }
         [Authorize(Roles = "Admin,Consultas")]
        // GET: /cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }
        [Authorize(Roles = "Admin")]
        // GET: /cursos/Create
        public ActionResult Create()
        {
            ViewBag.idColegio = new SelectList(db.Colegios, "idColegio", "NombreColegio");
            return View();
        }

        // POST: /cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idCurso,idColegio,nombreCurso")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idColegio = new SelectList(db.Colegios, "idColegio", "NombreColegio", cursos.idColegio);
            return View(cursos);
        }
         [Authorize(Roles = "Admin")]
        // GET: /cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idColegio = new SelectList(db.Colegios, "idColegio", "NombreColegio", cursos.idColegio);
            return View(cursos);
        }
        [Authorize(Roles = "Admin")]
        // POST: /cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idCurso,idColegio,nombreCurso")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idColegio = new SelectList(db.Colegios, "idColegio", "NombreColegio", cursos.idColegio);
            return View(cursos);
        }
        [Authorize(Roles = "Admin")]
        // GET: /cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }
         [Authorize(Roles = "Admin")]
        // POST: /cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
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
