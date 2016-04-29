using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar3ASP.Models;
using System.Web.Security;

namespace RentCar3ASP.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rental
        public ActionResult Index()
        {
            if (Roles.IsUserInRole("user"))
            { 
                List<RentalModels> RentalPerson = new List<RentalModels>();
                foreach (var x in db.Rental.ToList())
                {
                    if (x.PersonId == (int) Session["iduser"])
                    {
                        RentalPerson.Add(x);
                    }
                }
                return View(RentalPerson.ToList());
            }
            if (Roles.IsUserInRole("admin"))
            {

                return View(db.Rental.ToList());
            }
            return View();


        }

        // GET: Rental/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalModels rentalModels = db.Rental.Find(id);
            if (rentalModels == null)
            {
                return HttpNotFound();
            }
            return View(rentalModels);
        }

        // GET: Rental/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rental/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRental,Start,End,Priceperday,Estimated_Km,PersonId")] RentalModels rentalModels)
        {
            if (ModelState.IsValid)
            {
                rentalModels.PersonId =  (int) Session["iduser"];
                db.Rental.Add(rentalModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalModels);
        }

        // GET: Rental/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalModels rentalModels = db.Rental.Find(id);
            if (rentalModels == null)
            {
                return HttpNotFound();
            }
            return View(rentalModels);
        }

        // POST: Rental/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRental,Start,End,Priceperday,Estimated_Km,PersonId")] RentalModels rentalModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalModels);
        }

        // GET: Rental/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalModels rentalModels = db.Rental.Find(id);
            if (rentalModels == null)
            {
                return HttpNotFound();
            }
            return View(rentalModels);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalModels rentalModels = db.Rental.Find(id);
            db.Rental.Remove(rentalModels);
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
