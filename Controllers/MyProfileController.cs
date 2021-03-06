﻿using System;
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
    public class MyProfileController : Controller
    {
        private MIS4200Team7Context db = new MIS4200Team7Context();

        // GET: MyProfile
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ProfileInfos.ToList());
        }

        // GET: MyProfile/Details/5
        [Authorize]
        public ActionResult Details()
        {
            Guid id;
            Guid.TryParse(User.Identity.GetUserId(), out id);
            ProfileInfo profileInfo = db.ProfileInfos.Find(id);
            if (profileInfo == null)
            {
                return HttpNotFound();
            }
            return View(profileInfo);
        }

        // GET: MyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyProfile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,firstName,lastName,bizUnit,empTitle,hireDate,bio,phone,WorkEmail")] ProfileInfo profileInfo)
        {
            if (ModelState.IsValid)
            {
                profileInfo.ProfileId = Guid.NewGuid();
                db.ProfileInfos.Add(profileInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileInfo);
        }

        // GET: MyProfile/Edit/5
        public ActionResult Edit(Guid? id)
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

        // POST: MyProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,firstName,lastName,bizUnit,empTitle,hireDate,bio,phone,WorkEmail")] ProfileInfo profileInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileInfo);
        }

        // GET: MyProfile/Delete/5
        public ActionResult Delete(Guid? id)
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

        // POST: MyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
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
