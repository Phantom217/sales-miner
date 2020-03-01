using System.Data.Entity;
using System.Linq;
using System.Net;
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
            return View(db.tbl_eqpmt_kits_current.ToList());
        }

        // GET: CurrentEqpmt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_kits_current tbl_eqpmt_kits_current = db.tbl_eqpmt_kits_current.Find(id);
            if (tbl_eqpmt_kits_current == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_kits_current);
        }

        // GET: CurrentEqpmt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentEqpmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "machineID,kitID,id")] tbl_eqpmt_kits_current tbl_eqpmt_kits_current)
        {
            if (ModelState.IsValid)
            {
                db.tbl_eqpmt_kits_current.Add(tbl_eqpmt_kits_current);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_eqpmt_kits_current);
        }

        // GET: CurrentEqpmt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_kits_current tbl_eqpmt_kits_current = db.tbl_eqpmt_kits_current.Find(id);
            if (tbl_eqpmt_kits_current == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_kits_current);
        }

        // POST: CurrentEqpmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "machineID,kitID,id")] tbl_eqpmt_kits_current tbl_eqpmt_kits_current)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_eqpmt_kits_current).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_eqpmt_kits_current);
        }

        // GET: CurrentEqpmt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_kits_current tbl_eqpmt_kits_current = db.tbl_eqpmt_kits_current.Find(id);
            if (tbl_eqpmt_kits_current == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_kits_current);
        }

        // POST: CurrentEqpmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_eqpmt_kits_current tbl_eqpmt_kits_current = db.tbl_eqpmt_kits_current.Find(id);
            db.tbl_eqpmt_kits_current.Remove(tbl_eqpmt_kits_current);
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
