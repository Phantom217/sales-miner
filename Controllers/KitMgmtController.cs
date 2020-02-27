using System;
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
    public class KitMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: KitMgmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_kit> kitMgmt = entities.tbl_kit.ToList();

            return View(kitMgmt.ToList());
        }

        public ActionResult AddKit(tbl_kit kitAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_kit.Add(new tbl_kit
                {
                   kitID = kitAdd.kitID,
                   description = kitAdd.description,
                   filePath = kitAdd.filePath
                });


                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteKit(tbl_kit kitDelete)
        {
            tbl_kit tbl_kit = db.tbl_kit.Find(kitDelete.id);
            db.tbl_kit.Remove(tbl_kit);
            db.SaveChanges();
            return RedirectToAction("Index");
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
