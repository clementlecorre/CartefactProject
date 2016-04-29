using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RentCar3ASP.Models
{
    [Authorize]
    public class CarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Car
        public ActionResult Index(string search, string type)
        {
         
            if (search == null)
            {
                return View(db.Car.ToList());
            }

            switch (type)
            {
                case "Model":

                    var Model = db.Car.Where(c => c.Model.StartsWith(search));
                    return View(Model.ToList());

                    break;
                case "Brand":
                
                    
                    var Brand = db.Car.Where(c => c.Brand.StartsWith(search));
                    return View(Brand.ToList());

                    
                    break;
                case "LocationLatitude":
                


                    var LocationLatitude = db.Car.Where(c => c.Location.Latitude.Equals(search));
                    return View(LocationLatitude.ToList());
                    break;
                case "LocationLongitude":

                    var LocationLongitude = db.Car.Where(c => c.Location.Longitude.Equals(search));
                    return View(LocationLongitude.ToList());
                    break;

                default:
                    return View(db.Car.ToList());
                    break;
            }
                
      

        }
   



        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCar,Brand,Model,Description,Buying_Date,Km,Status,Location")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                
                db.Car.Add(carModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carModels);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // POST: Car/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCar,Brand,Model,Description,Buying_Date,Km")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {              
                db.Entry(carModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carModels);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModels carModels = db.Car.Find(id);
            db.Car.Remove(carModels);
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
