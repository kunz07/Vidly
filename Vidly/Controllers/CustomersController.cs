using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
           return View("Index");
        }

        // GET: Customers/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            var memberships = db.MembershipTypes.ToList();
            var membershipList = new CustomerDetailsViewModel()
            {
                Customer = customer,
                MembershipTypes = memberships
            };
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(membershipList);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MembershipName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,MembershipTypeID,Name,DateOfBirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MembershipName", customer.MembershipTypeID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MembershipName", customer.MembershipTypeID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,MembershipTypeID,Name,DateOfBirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MembershipName", customer.MembershipTypeID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            var memberships = db.MembershipTypes.ToList();
            var membershiplist = new CustomerDetailsViewModel()
            {
                Customer = customer,
                MembershipTypes = memberships
            };
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(membershiplist);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
