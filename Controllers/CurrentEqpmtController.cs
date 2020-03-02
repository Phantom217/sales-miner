using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class CurrentEqpmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CurrentEqpmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_eqpmt_kits_current> currentKits = entities.tbl_eqpmt_kits_current.ToList();
            return View(currentKits);
        }

        [HttpPost]
        public ActionResult AddKit(tbl_eqpmt_kits_current addKit)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_eqpmt_kits_current.Add(new tbl_eqpmt_kits_current
                {
                    machineID = addKit.machineID,
                    kitID = addKit.kitID,
                });

                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteKit(tbl_eqpmt_kits_current deleteKit)
        {
            tbl_eqpmt_kits_current currentKit = db.tbl_eqpmt_kits_current.Find(deleteKit.id);
            db.tbl_eqpmt_kits_current.Remove(currentKit);
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
