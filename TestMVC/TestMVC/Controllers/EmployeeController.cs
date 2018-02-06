using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.TestMVC.BLL;
using TestMVC.ViewModels;

namespace TestMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }

        public Customer GetCustomer()
        {
            Customer cu = new Customer { CustomerName = "Customer 1", Address = "Address 1" };

            //这里会调用重写的ToString
            return cu;
        }

        public ActionResult Index()
        {
            EmployeeBusinessLayer blEmp = new EmployeeBusinessLayer();
            List<Employee> emps = blEmp.GetEmployees();

            List<EmployeeViewModel> vmEmp = new List<EmployeeViewModel>();

            foreach (Employee item in emps)
            {
                EmployeeViewModel temp = new EmployeeViewModel() { EmployeeName = item.FirstName + " " + item.LastName, Salary = item.Salary.ToString("C") };

                if (item.Salary > 15000)
                    temp.SalaryColor = "yellow";
                else
                    temp.SalaryColor = "green";
                vmEmp.Add(temp);
            }

            EmployeeListViewModel lvmEmp = new EmployeeListViewModel();
            lvmEmp.Employees = vmEmp;

            return View("Index", lvmEmp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                case "Cancel":
                    return RedirectToAction("Index");
                default:
                    break;
            }

            return new EmptyResult();
        }
    }

    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        //在返回这个对象的时候会默认调用这个
        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }
    }
}