using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JJC_Music_Store_v_1_3.Models;
using JJC_Music_Store_v_1_3.Models.Entity;
using JJC_Music_Store_v_1_3.Models.Abstract;
using System.Diagnostics;
using JJC_Music_Store_v_1_3.Models.Repositories;

namespace JJC_Music_Store_v_1_3.Controllers
{
    public class CartModelController : Controller
    {
       
        
        // GET: CartModel
        public ActionResult Index()
        {
            CartModel CartModel = (CartModel)Session["CartModel"];

            List<IProduct> results = new List<IProduct>();

            if (Session["CartModel"] != null)
              
            {
                if (CartModel.Products.Count != 0)
                {
                    // CartModel CartModel = (CartModel)Session["CartModel"];

                    //ViewBag.CartModel = CartModel;


                   results = CartModel.Products.Cast<IProduct>().ToList();

                    Debug.WriteLine(results.First<IProduct>().GetName());

                    foreach (var v in results)
                    {

                        //if (v.GetType().Equals(new SongModel()))
                        //{
                        var song = (SongModel)v;


                        v.Name = song.SongName;
                        v.artistID = song.ArtistModelID;
                        v.genreID = song.GenreModelID;
                        v.ProductID = song.SongModelID;
                        v.Price = song.Price;
                        // }





                    }

                    return View(results);
                }
               
            }

            return View(results);


        }

        public ActionResult CheckOut()
        {

        IOrder orderRepo = new IOrderImplementation();

            OrderModel order = new OrderModel();

            CartModel CartModel = (CartModel)Session["CartModel"];
            int price = 0;
            foreach(var v in CartModel.Products)
            {
                price += v.Price;
            }


            order.Price = price;

            orderRepo.InsertOrUpdate(order);

            Session["CartModel"] = new CartModel();

            return RedirectToAction("Index");
        }
    


        // GET: CartModel/Details/5
        public ActionResult Details(int id)
        {
            CartModel CartModel = (CartModel)Session["CartModel"];

            IProduct product = CartModel.Products.Find(x => x.ProductID == id);

            

            var song = (SongModel)product;


            product.Name = song.SongName;
           /* .artistID = song.ArtistModelID;
            v.genreID = song.GenreModelID;
            v.ProductID = song.SongModelID;
            v.Price = song.Price;
            // }*/





        

                   



           


            return View(product);
        }

        // GET: CartModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartModel/Create
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

        // GET: CartModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartModel/Edit/5
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

        // GET: CartModel/Delete/5
        public ActionResult Delete(int id)
        {
            CartModel CartModel = (CartModel)Session["CartModel"];

            
               

            CartModel.Products.Remove(CartModel.Products.Find(x => x.ProductID == id));



            return RedirectToAction("Index");
        }

        // POST: CartModel/Delete/5
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
