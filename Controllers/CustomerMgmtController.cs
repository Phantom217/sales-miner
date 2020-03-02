using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class CustomerMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerMgmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_customer> custMgmt = entities.tbl_customer.ToList();

            return View(custMgmt);
            //return View(db.tbl_customer.ToList());
        }
                  
        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddCustomer(tbl_customer customerAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_customer.Add(new tbl_customer
                {
                    customerCode = customerAdd.customerCode,
                    name = customerAdd.name,
                    address = customerAdd.address,
                    city = customerAdd.city,
                    state = customerAdd.state,
                    zipCode = customerAdd.zipCode,
                });


                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteCustomer(tbl_customer custDelete)
        {
            tbl_customer tbl_customer = db.tbl_customer.Find(custDelete.id);
            db.tbl_customer.Remove(tbl_customer);
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
