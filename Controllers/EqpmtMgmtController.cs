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
    public class EqpmtMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: EqpmtMgmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_eqpmt_type> eqpmtMgmt = entities.tbl_eqpmt_type.ToList();

            ViewBag.eqpmtType = new SelectList(db.tbl_eqpmt_type_mgmt.OrderBy(x => x.eqpmtType), "eqpmtType", "eqpmtType");

            return View(eqpmtMgmt.ToList());

        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddEqpmt(tbl_eqpmt_type eqpmtAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_eqpmt_type.Add(new tbl_eqpmt_type
                {
                    eqpmtType = eqpmtAdd.eqpmtType,
                    model = eqpmtAdd.model,
                    description = eqpmtAdd.description
                });


                entities.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteEqpmt(tbl_eqpmt_type eqpmtDelete)
        {
            tbl_eqpmt_type tbl_eqpmt_type = db.tbl_eqpmt_type.Find(eqpmtDelete.id);
            db.tbl_eqpmt_type.Remove(tbl_eqpmt_type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateEqpmt(tbl_eqpmt_type eqpmtUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_eqpmt_type updatedEqpmt = (from c in entities.tbl_eqpmt_type
                    where c.id == eqpmtUpdate.id
                    select c).FirstOrDefault();
                updatedEqpmt.eqpmtType = eqpmtUpdate.eqpmtType;
                updatedEqpmt.model = eqpmtUpdate.model;
                updatedEqpmt.description = eqpmtUpdate.description;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        //end CMPS 411 controller code
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
