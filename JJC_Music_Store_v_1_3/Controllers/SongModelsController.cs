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
using System.Diagnostics;

namespace JJC_Music_Store_v_1_3.Controllers
{
    public class SongModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
       
          

        

       public ActionResult AddToCart(int? id)
            {

            if(Session["CartModel"] == null)
            {


                return RedirectToAction("Index");
            }
            else if(Session["CartModel"] != null)
                {


                CartModel CartModel = (CartModel)Session["CartModel"];

                CartModel.Products.Add(db.SongModels.Find(id));

                Session["CartModel"] = CartModel;



              /*  Debug.WriteLine(CartModel.Products.OfType<IProduct>().First<IProduct>().GetName());
                Debug.WriteLine(CartModel.Products.OfType<IProduct>().First<IProduct>().GetID());
                Debug.WriteLine(CartModel.Products.Count);*/


               
                return RedirectToAction("Index");
                }

            return RedirectToAction("Index");

        }



        // GET: SongModels
        public ActionResult Index()
        {
            if (Session["CartModel"] == null)
            {
                try
                {

                    Session.Add("CartModel", new CartModel());
                }
                catch (NotImplementedException)
                {
                    //throw new NotImplementedException();
                }
            }

            var songModels = db.SongModels.Include(s => s.ArtistModels).Include(s => s.GenreModels);

            foreach(var v in songModels)
            {
                v.Name = v.SongName;
            }

            return View(songModels.ToList());
        }

        // GET: SongModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongModel songModel = db.SongModels.Find(id);
            if (songModel == null)
            {
                return HttpNotFound();
            }
            return View(songModel);
        }

        // GET: SongModels/Create
        public ActionResult Create()
        {
            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName");
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName");
            return View();
        }

        // POST: SongModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongModelID,SongName,ArtistModelID,GenreModelID,Price")] SongModel songModel)
        {
            if (ModelState.IsValid)
            {
                db.SongModels.Add(songModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName", songModel.ArtistModelID);
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName", songModel.GenreModelID);
            return View(songModel);
        }

        // GET: SongModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongModel songModel = db.SongModels.Find(id);
            if (songModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName", songModel.ArtistModelID);
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName", songModel.GenreModelID);
            return View(songModel);
        }

        // POST: SongModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongModelID,SongName,ArtistModelID,GenreModelID,Price")] SongModel songModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(songModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistModelID = new SelectList(db.ArtistModels, "ArtistModelID", "ArtistName", songModel.ArtistModelID);
            ViewBag.GenreModelID = new SelectList(db.GenreModels, "GenreModelID", "GenreName", songModel.GenreModelID);
            return View(songModel);
        }

        // GET: SongModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongModel songModel = db.SongModels.Find(id);
            if (songModel == null)
            {
                return HttpNotFound();
            }
            return View(songModel);
        }

        // POST: SongModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SongModel songModel = db.SongModels.Find(id);
            db.SongModels.Remove(songModel);
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
