using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSharpProjectV3.DAL;
using CSharpProjectV3.Models;

namespace CSharpProjectV3.Controllers
{
    public class DaylilyController : Controller
    {
        //Separate GET and POST request for added security in POST methods.

        private DaylilyContext db = new DaylilyContext();

        // GET: Daylily
        public ActionResult Index()
        {
            return View(db.Daylilies.ToList());
        }

        // GET: Daylily/Details
        // If Id or daylily null, return bad request or HTTP not found response.  If not, find the id and display it.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daylily daylily = db.Daylilies.Find(id);
            if (daylily == null)
            {
                return HttpNotFound();
            }
            return View(daylily);
        }

        // GET: Daylily/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Daylily/Create
        // Using Bind from here on to limit the fields available for CRUD activity.  No hidden or secret fields yet, but programming in advance.
        //Antiforgery token used for extra security to detect form submissions from other sites.  Compares HTTP cookie to value written into form and returns error if not matching
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Color,Height,BloomSize")] Daylily daylily)
        {
            if (ModelState.IsValid)
            {
                db.Daylilies.Add(daylily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daylily);
        }

        // GET: Daylily/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daylily daylily = db.Daylilies.Find(id);
            if (daylily == null)
            {
                return HttpNotFound();
            }
            return View(daylily);
        }

        // POST: Daylily/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Color,Height,BloomSize")] Daylily daylily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daylily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daylily);
        }

        // GET: Daylily/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daylily daylily = db.Daylilies.Find(id);
            if (daylily == null)
            {
                return HttpNotFound();
            }
            return View(daylily);
        }

        // POST: Daylily/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Daylily daylily = db.Daylilies.Find(id);
            db.Daylilies.Remove(daylily);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Clean up unmanaged resources.

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
