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
using Business.Interfaces;
using Business;

namespace colegio7.Controllers
{
    
    public class EstudiantesController : Controller
    {
        private IEstudiantesServices estudiantesServices = new EstudiantesServices();
        private ColegioEntities db = new ColegioEntities();

        // [Authorize(Roles = "Admin,Consultas")]
        // GET: /Estudiantes/
        public ActionResult Index()
        {
            var estudiantes = db.Estudiantes.Include(e => e.Barrios).Include(e => e.Cursos);
            return View(estudiantes.ToList());
        }

         [Authorize(Roles = "Admin,Consultas")]
        // GET: /Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            List<string> nombresMateria = new List<string>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            var materias = db.Estudiantes.Join(db.CursoMateria, a => a.idCurso, b => b.idCurso, (a, b) => new { b.idMateria, a.idEstudiante })
                                                .Join(db.Materias, c => c.idMateria, d => d.idMateria, (c, d) => new { d.nombreMateria, c.idEstudiante }).Where(e => e.idEstudiante == id).ToList();

            foreach(var materia in materias){
                 string nuevaMateria = materia.nombreMateria;
                 nombresMateria.Add(nuevaMateria);            
            }

            ViewBag.materias = nombresMateria;

            return View(estudiantes);
        }
        [Authorize(Roles = "Admin")]
        // GET: /Estudiantes/Create
        public ActionResult Create()
        {
            ViewBag.idBarrio = new SelectList(db.Barrios, "idBarrio", "nombreBarrio");
            ViewBag.idCurso = new SelectList(db.Cursos, "idCurso", "nombreCurso");
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: /Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idEstudiante,numeroIdentificacion,nombre,apellido,direccion,idBarrio,idCurso")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Estudiantes.Add(estudiantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBarrio = new SelectList(db.Barrios, "idBarrio", "nombreBarrio", estudiantes.idBarrio);
            ViewBag.idCurso = new SelectList(db.Cursos, "idCurso", "nombreCurso", estudiantes.idCurso);
            return View(estudiantes);
        }
        [Authorize(Roles = "Admin")]
        // GET: /Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBarrio = new SelectList(db.Barrios, "idBarrio", "nombreBarrio", estudiantes.idBarrio);
            ViewBag.idCurso = new SelectList(db.Cursos, "idCurso", "nombreCurso", estudiantes.idCurso);
            return View(estudiantes);
        }

        [Authorize(Roles = "Admin")]
        // POST: /Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idEstudiante,numeroIdentificacion,nombre,apellido,direccion,idBarrio,idCurso")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBarrio = new SelectList(db.Barrios, "idBarrio", "nombreBarrio", estudiantes.idBarrio);
            ViewBag.idCurso = new SelectList(db.Cursos, "idCurso", "nombreCurso", estudiantes.idCurso);
            return View(estudiantes);
        }

         [Authorize(Roles = "Admin")]
        // GET: /Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             
                Estudiantes estudiantes = db.Estudiantes.Find(id);
            
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        [Authorize(Roles = "Admin")]
        // POST: /Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantesServices.validarMinimos(id))
            {
                db.Estudiantes.Remove(estudiantes);
                db.SaveChanges();
            }
            else
            {
                TempData["Message"] = "Deben ser minímo 2 estudiantes, máximo 6 por curso";
            }
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
