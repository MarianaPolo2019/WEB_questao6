using AlunoProva.Context;
using AlunoProva.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlunoProva.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Contexto db = new Contexto();
        // GET: Aluno
        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
        }

        #region Create - GET
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(AlunoModel aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
        #endregion

        #region Details 
        [HttpGet]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel aluno = db.Alunos.Where(a => a.Id == id).FirstOrDefault();
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel aluno = db.Alunos.Where(a => a.Id == id).FirstOrDefault();
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }
        #endregion

        #region Edit - POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlunoModel aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoModel aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}