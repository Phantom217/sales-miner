using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class EqpmtKitsController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: EqpmtKits
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_eqpmt_kits_avlbl> available_kits = entities.tbl_eqpmt_kits_avlbl.ToList();

            return View(available_kits);
        }

        [HttpPost]
        public ActionResult AddKit(tbl_eqpmt_kits_avlbl kitAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_eqpmt_kits_avlbl.Add(new tbl_eqpmt_kits_avlbl
                {
                    kitID = kitAdd.kitID,
                    eqpmtType = kitAdd.eqpmtType,
                });

                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteKit(tbl_eqpmt_kits_avlbl kitDelete)
        {
            tbl_eqpmt_kits_avlbl available_kits = db.tbl_eqpmt_kits_avlbl.Find(kitDelete.id);
            db.tbl_eqpmt_kits_avlbl.Remove(available_kits);
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
