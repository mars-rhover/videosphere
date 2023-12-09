using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Movie,Title,Duration,ReleaseDate,IsTvShow,Genre,IsMovie,Description,Rating,Poster,DateOfUpload")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Movie,Title,Duration,ReleaseDate,IsTvShow,Genre,IsMovie,Description,Rating,Poster,DateOfUpload")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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

        public ActionResult AddToCart(int id)
        {

            var movieToAdd = db.Movies.Find(id);
            var userCart = (ShoppingCart)Session["ShoppingCart"];
            userCart.Items.Add(movieToAdd);
            Session["ShoppingCart"] = userCart;
         
            // Votre logique pour ajouter un produit au panier
            return RedirectToAction("Index");
        }
        public ActionResult CartView()
        {
            return View();
        }

        public ActionResult RemoveFromCart(int movieId)
        {
            var shoppingCart = Session["ShoppingCart"] as ShoppingCart;
            if (shoppingCart != null)
            {
                // Find and remove the item from the cart based on the product ID
                var itemToRemove = shoppingCart.Items.FirstOrDefault(item => item.id_Movie == movieId);
                if (itemToRemove != null)
                {
                    shoppingCart.Items.Remove(itemToRemove);
                }
            }
          
            

            return RedirectToAction("Index", "Movies"); // Redirect to the cart or home page
        }
        public ActionResult Checkout()
        {
            var shoppingCart = Session["ShoppingCart"] as ShoppingCart;
            if (shoppingCart != null && shoppingCart.Items.Any())
            {
                // Implement your checkout logic here (e.g., gather user information, confirm order, etc.)

                // For simplicity, clear the shopping cart after checkout
                shoppingCart.Items.Clear();
                Session["ShoppingCart"] = shoppingCart;

                return View("CheckoutConfirmation");
            }
            else
            {
                return RedirectToAction("Index", "Movies"); // Redirect to home if the cart is empty
            }
        }









    }
}
