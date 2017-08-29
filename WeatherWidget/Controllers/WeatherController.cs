using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WeatherWidget.Models
{
    [Authorize(Roles ="Administrator")]
    public class WeatherController : Controller
    {
        private WeatherDbContext db = new WeatherDbContext();

        // GET: Weather
        public ActionResult Index()
        {
            return View(db.Weather.ToList());
        }

        // GET: Weather/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weather weather = db.Weather.Find(id);
            if (weather == null)
            {
                return HttpNotFound();
            }
            return View(weather);
        }

        // GET: Weather/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weather/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ZipCode,PrecipitationChance,Temperature,Description")] Weather weather)
        {
            if (ModelState.IsValid)
            {
                db.Weather.Add(weather);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weather);
        }

        // GET: Weather/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weather weather = db.Weather.Find(id);
            if (weather == null)
            {
                return HttpNotFound();
            }
            return View(weather);
        }

        // POST: Weather/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ZipCode,PrecipitationChance,Temperature,Description")] Weather weather)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weather);
        }

        // GET: Weather/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weather weather = db.Weather.Find(id);
            if (weather == null)
            {
                return HttpNotFound();
            }
            return View(weather);
        }

        // POST: Weather/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weather weather = db.Weather.Find(id);
            db.Weather.Remove(weather);
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
