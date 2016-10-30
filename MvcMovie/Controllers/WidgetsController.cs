﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class WidgetsController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Widgets
        public ActionResult Index()
        {
            return View(db.Widgets.ToList());
        }

        // GET: Widgets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = db.Widgets.Find(id);
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        // GET: Widgets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Widgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BasePrice,DiscountIndicator")] Widget widget)
        {
            if (ModelState.IsValid)
            {
                db.Widgets.Add(widget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(widget);
        }

        // GET: Widgets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = db.Widgets.Find(id);
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        // POST: Widgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BasePrice,DiscountIndicator")] Widget widget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(widget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(widget);
        }

        // GET: Widgets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = db.Widgets.Find(id);
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        // POST: Widgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Widget widget = db.Widgets.Find(id);
            db.Widgets.Remove(widget);
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
