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
    public class ProfileInfoesController : Controller
    {
        private MIS4200Team7Context db = new MIS4200Team7Context();

        // GET: ProfileInfoes
        public ActionResult Index()
        {
            return View(db.ProfileInfos.ToList());
        }

        // GET: ProfileInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileInfo profileInfo = db.ProfileInfos.Find(id);
            if (profileInfo == null)
            {
                return HttpNotFound();
            }
            return View(profileInfo);
        }

        // GET: ProfileInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profileId,firstName,lastName,fullname,bizUnit,hireDate,bio,phone,email")] ProfileInfo profileInfo)
        {
            if (ModelState.IsValid)
            {
                db.ProfileInfos.Add(profileInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileInfo);
        }

        // GET: ProfileInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileInfo profileInfo = db.ProfileInfos.Find(id);
            if (profileInfo == null)
            {
                return HttpNotFound();
            }
            return View(profileInfo);
        }

        // POST: ProfileInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profileId,firstName,lastName,fullname,bizUnit,hireDate,bio,phone,email")] ProfileInfo profileInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileInfo);
        }

        // GET: ProfileInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileInfo profileInfo = db.ProfileInfos.Find(id);
            if (profileInfo == null)
            {
                return HttpNotFound();
            }
            return View(profileInfo);
        }

        // POST: ProfileInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileInfo profileInfo = db.ProfileInfos.Find(id);
            db.ProfileInfos.Remove(profileInfo);
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
