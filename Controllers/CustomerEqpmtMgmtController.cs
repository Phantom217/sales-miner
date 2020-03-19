﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class CustomerEqpmtMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerEqpmtMgmt
        public ActionResult Index()
        {
            return View(db.tbl_customer_eqpmt.ToList());
        }

        // GET: CustomerEqpmtMgmt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            if (tbl_customer_eqpmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer_eqpmt);
        }

        // GET: CustomerEqpmtMgmt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerEqpmtMgmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerCode,machineID,jobNum,eqpmtType,id")] tbl_customer_eqpmt tbl_customer_eqpmt)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customer_eqpmt.Add(tbl_customer_eqpmt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_customer_eqpmt);
        }

        // GET: CustomerEqpmtMgmt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            if (tbl_customer_eqpmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer_eqpmt);
        }

        // POST: CustomerEqpmtMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerCode,machineID,jobNum,eqpmtType,id")] tbl_customer_eqpmt tbl_customer_eqpmt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customer_eqpmt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_customer_eqpmt);
        }

        // GET: CustomerEqpmtMgmt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            if (tbl_customer_eqpmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer_eqpmt);
        }

        // POST: CustomerEqpmtMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            db.tbl_customer_eqpmt.Remove(tbl_customer_eqpmt);
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