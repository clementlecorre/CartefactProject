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
    public class PersonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Person
        public ActionResult Index()
        {
            if(Roles.IsUserInRole("admin"))
            {
                var person = db.Person.Include(p => p.User);
                return View(person.ToList());
            }
            else
            {
                return View();
            }
                
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if ((id == (int)Session["iduser"]) || (Roles.IsUserInRole("admin")))
            {
                
                PersonModels personModels = db.Person.Find(id);
                string[] roleuser = Roles.GetRolesForUser(personModels.Email); 
                ViewBag.role = roleuser[0];
                return View(personModels);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Person, "Id", "Email");
            return View();
        }

        // POST: Person/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPerson,Email,Name,Nickname,Driving_habits,Driver_experience,ApplicationUserId")] PersonModels personModels)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(personModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Person, "Id", "Email", personModels.ApplicationUserId);
            return View(personModels);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {

                      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModels personModels = db.Person.Find(id);
            if (personModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Person, "Id", "Email", personModels.ApplicationUserId);
            return View(personModels);
        }

        // POST: Person/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPerson,Email,Name,Nickname,Driving_habits,Driver_experience,ApplicationUserId")] PersonModels personModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Person, "Id", "Email", personModels.ApplicationUserId);
            return View(personModels);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModels personModels = db.Person.Find(id);
            if (personModels == null)
            {
                return HttpNotFound();
            }
            return View(personModels);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonModels personModels = db.Person.Find(id);
            db.Person.Remove(personModels);
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
