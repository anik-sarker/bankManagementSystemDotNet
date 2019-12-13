using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMS.Models;

namespace BMS.Controllers
{
    public class LoginsController : Controller
    {
        ApplicationDbContext db=new ApplicationDbContext();
        // GET: Logins
        [HttpGet]
        public ActionResult login()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult login(Login login)
        {
            var unitofwork = new UnitOFWork.UnitOfWork(new ApplicationDbContext());

            string role = unitofwork.UserInfo.getUserRole(login.UserId,login.Password);
            if (role == "Man")
            {
               Manager man = unitofwork.Manager.Get(login.UserId);
               Session["username"] = man.Name;
               Session["ui"] = man.Id;
               Session["bi"] = man.BranchId;

               return RedirectToAction("Home","Managers");

            }

            else if (role=="Cus")
            {
                Customer cus = unitofwork.Customer.Get(login.UserId);
                Session["username"] = cus.Name;
                Session["ui"] = cus.Id;
                Session["bi"] = cus.BranchId;

                return RedirectToAction("Index", "Customers");  // dummy dashboard for customer
            }

            else if (role =="Emp")
            {
                Employee emp = unitofwork.Employee.Get(login.UserId);
                Session["username"] = emp.Name;
                Session["ui"] = emp.Id;
                Session["bi"] = emp.BranchId;

                return RedirectToAction("Home", "Employees"); 
            }

            else if (role == "md")
            {
                Md md = db.Mds.Find(login.UserId);
              
                Session["username"] = md.Name;
                Session["ui"] = md.Id;
                return RedirectToAction("Index", "Md");
            }
            else
            {
                Session["error"] =role;
                return RedirectToAction("login");

            }

            
        }

        public ActionResult test(UserInfo ui)
        {
            return View(ui);
        }


        public ActionResult Register()
        {
            ViewBag.AccountTypeId = new SelectList(db.CusAccountTypes, "Id", "AccType");
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Name,DateOfBirth,Email,Address,Gender,NID,BranchId,Balance,AccountTypeId,JoinDate,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("login");
            }

            ViewBag.AccountTypeId = new SelectList(db.CusAccountTypes, "Id", "AccType", customer.AccountTypeId);
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", customer.BranchId);
            return View(customer);
        }
    }
}