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
    public class AlbumModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AlbumModels
        public ActionResult Index()
        {
            var albumModels = db.AlbumModels.Include(a => a.ArtistModels).Include(a => a.GenreModels);
            return View(albumModels.ToList());
        }

        // GET: AlbumModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumModel albumModel = db.AlbumModels.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            return View(albumModel);
        }

        // GET: AlbumModels/Create
        public ActionResult Create()
        {
            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName");
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName");
            return View();
        }

        // POST: AlbumModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumModelID,AlbumName,ArtistModelID,GenreModelID,Price")] AlbumModel albumModel)
        {
            if (ModelState.IsValid)
            {
                db.AlbumModels.Add(albumModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName", albumModel.ArtistModelID);
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName", albumModel.GenreModelID);
            return View(albumModel);
        }

        // GET: AlbumModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumModel albumModel = db.AlbumModels.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName", albumModel.ArtistModelID);
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName", albumModel.GenreModelID);
            return View(albumModel);
        }

        // POST: AlbumModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumModelID,AlbumName,ArtistModelID,GenreModelID,Price")] AlbumModel albumModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName", albumModel.ArtistModelID);
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName", albumModel.GenreModelID);
            return View(albumModel);
        }

        // GET: AlbumModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumModel albumModel = db.AlbumModels.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            return View(albumModel);
        }

        // POST: AlbumModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumModel albumModel = db.AlbumModels.Find(id);
            db.AlbumModels.Remove(albumModel);
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
