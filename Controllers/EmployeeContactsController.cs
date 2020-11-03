using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200ProjectTeam7.DAL;
using MIS4200ProjectTeam7.Models;

namespace MIS4200ProjectTeam7.Controllers
{
    public class EmployeeContactsController : Controller
    {
        private MIS4200Team7Context db = new MIS4200Team7Context();

        // GET: EmployeeContacts
        public ActionResult Index()
        {
            return View(db.EmployeeContacts.ToList());
        }

        // GET: EmployeeContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeContact employeeContact = db.EmployeeContacts.Find(id);
            if (employeeContact == null)
            {
                return HttpNotFound();
            }
            return View(employeeContact);
        }

        // GET: EmployeeContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,firstName,lastName,empTitle,phone,email")] EmployeeContact employeeContact)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeContacts.Add(employeeContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeContact);
        }

        // GET: EmployeeContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeContact employeeContact = db.EmployeeContacts.Find(id);
            if (employeeContact == null)
            {
                return HttpNotFound();
            }
            return View(employeeContact);
        }

        // POST: EmployeeContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,firstName,lastName,empTitle,phone,email")] EmployeeContact employeeContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeContact);
        }

        // GET: EmployeeContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeContact employeeContact = db.EmployeeContacts.Find(id);
            if (employeeContact == null)
            {
                return HttpNotFound();
            }
            return View(employeeContact);
        }

        // POST: EmployeeContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeContact employeeContact = db.EmployeeContacts.Find(id);
            db.EmployeeContacts.Remove(employeeContact);
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
