using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JJC_Music_Store_v_1_3.Models;
using JJC_Music_Store_v_1_3.Models.Entity;

namespace JJC_Music_Store_v_1_3.Controllers
{
    public class GenreModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GenreModels
        public ActionResult Index()
        {
            return View(db.GenreModels.ToList());
        }

        // GET: GenreModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genreModel = db.GenreModels.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);
        }

        // GET: GenreModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreModelID,GenreName")] GenreModel genreModel)
        {
            if (ModelState.IsValid)
            {
                db.GenreModels.Add(genreModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genreModel);
        }

        // GET: GenreModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genreModel = db.GenreModels.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);
        }

        // POST: GenreModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreModelID,GenreName")] GenreModel genreModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genreModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genreModel);
        }

        // GET: GenreModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genreModel = db.GenreModels.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);
        }

        // POST: GenreModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenreModel genreModel = db.GenreModels.Find(id);
            db.GenreModels.Remove(genreModel);
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
