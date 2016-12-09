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
    public class ArtistModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtistModels
        public ActionResult Index()
        {
            return View(db.ArtistModels.ToList());
        }

        // GET: ArtistModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistModel artistModel = db.ArtistModels.Find(id);
            if (artistModel == null)
            {
                return HttpNotFound();
            }
            return View(artistModel);
        }

        // GET: ArtistModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistModelID,ArtistName")] ArtistModel artistModel)
        {
            if (ModelState.IsValid)
            {
                db.ArtistModels.Add(artistModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artistModel);
        }

        // GET: ArtistModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistModel artistModel = db.ArtistModels.Find(id);
            if (artistModel == null)
            {
                return HttpNotFound();
            }
            return View(artistModel);
        }

        // POST: ArtistModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistModelID,ArtistName")] ArtistModel artistModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artistModel);
        }

        // GET: ArtistModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistModel artistModel = db.ArtistModels.Find(id);
            if (artistModel == null)
            {
                return HttpNotFound();
            }
            return View(artistModel);
        }

        // POST: ArtistModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistModel artistModel = db.ArtistModels.Find(id);
            db.ArtistModels.Remove(artistModel);
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
