using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;
using MIS4200ProjectTeam7.DAL;
using MIS4200ProjectTeam7.Models;

namespace MIS4200ProjectTeam7.Controllers
{
    public class ProfileInfoesController : Controller
    {
        private MIS4200Team7Context db = new MIS4200Team7Context();

        // GET: ProfileInfoes
        [Authorize]
       
        public ActionResult Index()
        { 
            var profileinfo = db.ProfileInfos.Include(p => p.nominator).OrderBy(p => p.firstName);
            
            profileinfo = profileinfo.OrderByDescending(p => p.nominator.Count());
           
            var profileList = profileinfo.ToList();
                 return View(profileList);

        }

               

        // GET: ProfileInfoes/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
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
        public ActionResult ProfDetails()
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

        public ActionResult EmployeeContact()
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
        public ActionResult Create([Bind(Include = "ProfileId,firstName,lastName,bizUnit,empTitle,hireDate,bio,phone,WorkEmail")] ProfileInfo profileInfo)
        {
            if (ModelState.IsValid)
            {
                Guid id;
                Guid.TryParse(User.Identity.GetUserId(), out id);
                profileInfo.ProfileId = id;
                db.ProfileInfos.Add(profileInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileInfo);
        }

        // GET: ProfileInfoes/Edit/5

        [Authorize]
        public ActionResult Edit()
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

        // POST: ProfileInfoes/Edit/5
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

        // GET: ProfileInfoes/Delete/5
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

        // POST: ProfileInfoes/Delete/5
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
