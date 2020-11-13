using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200ProjectTeam7.DAL;
using MIS4200ProjectTeam7.Models;

namespace MIS4200ProjectTeam7.Controllers
{
    public class CoreValuesController : Controller
    {
        private MIS4200Team7Context db = new MIS4200Team7Context();

        // GET: CoreValues

        [Authorize]
        public ActionResult Index()
        {
            var coreValues = db.CoreValues.Include(c => c.nominator).Include(c => c.nominee);
            return View(coreValues.ToList());
        }

        // GET: CoreValues/Details/5

        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValues coreValues = db.CoreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            return View(coreValues);
        }
        public ActionResult Recognition(int? id)
        {
            var rec = db.CoreValues.Where(r => r.ID == id);
            var recList = rec.ToList();


            var totalCnt = recList.Count(); //counts all the recognitions for that person
            var rec01Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Excellence);
            var rec2Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Culture);
            var rec3Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Integrity);
            var rec4Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Stewardship);
            var rec5Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Balance);
            var rec6Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Innovate);
            var rec7Cnt = recList.Count(r => r.award == CoreValues.CoreValue.Passion);
            // copy the values into the ViewBag
            ViewBag.Total = totalCnt;
            ViewBag.Excellence = rec01Cnt;
            ViewBag.Culture = rec2Cnt;
            ViewBag.Integrity = rec3Cnt;
            ViewBag.Stewardship = rec4Cnt;
            ViewBag.Balance = rec5Cnt;
            ViewBag.Innovate = rec6Cnt;
            ViewBag.Passion = rec7Cnt;

            return View();
        }


        // GET: CoreValues/Create
        public ActionResult Create()
        {
            string ProfileId = User.Identity.GetUserId();
           SelectList employees = new SelectList(db.ProfileInfos, "ProfileId", "fullName");
            employees = new SelectList(employees.Where(x => x.Value != ProfileId).ToList(), "Value", "Text");
            ViewBag.recognized = employees;
            ViewBag.recognizor = employees;
            ViewBag.recognizor = new SelectList(db.ProfileInfos, "ProfileId", "fullName");
            return View();
        }

        // POST: CoreValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,award,recognizor,recognized,description,recognizationDate")] CoreValues coreValues)
        {
            if (ModelState.IsValid)
            {
                db.CoreValues.Add(coreValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recognizor = new SelectList(db.ProfileInfos, "ProfileId", "firstName", coreValues.recognizor);
            ViewBag.recognized = new SelectList(db.ProfileInfos, "ProfileId", "firstName", coreValues.recognized);
            return View(coreValues);
        }

        // GET: CoreValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValues coreValues = db.CoreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            ViewBag.recognizor = new SelectList(db.ProfileInfos, "ProfileId", "fullName",  coreValues.recognizor);
            ViewBag.recognized = new SelectList(db.ProfileInfos, "ProfileId", "fullName", coreValues.recognized);
            return View(coreValues);
        }

        // POST: CoreValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,award,recognizor,recognized,description,recognizationDate")] CoreValues coreValues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recognizor = new SelectList(db.ProfileInfos, "ProfileId", "fullName", coreValues.recognizor);
            ViewBag.recognized = new SelectList(db.ProfileInfos, "ProfileId", "fullName", coreValues.recognized);
            return View(coreValues);
        }

        // GET: CoreValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValues coreValues = db.CoreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            return View(coreValues);
        }

        // POST: CoreValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoreValues coreValues = db.CoreValues.Find(id);
            db.CoreValues.Remove(coreValues);
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
