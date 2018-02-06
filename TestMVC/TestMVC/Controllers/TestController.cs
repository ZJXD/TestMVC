using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.ViewModels;

namespace TestMVC.Controllers
{
    public class TestController : Controller
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

        // 测试 ViewData 和 ViewBag
        //public ActionResult GetView()
        //{
        //    Employee emp = new Employee();
        //    emp.FirstName = "Sukesh";
        //    emp.LastName = "Marla";
        //    emp.Salary = 20000;
        //    //ViewData["Employee"] = emp;
        //    ViewBag.Employee = emp;
        //    return View("MyView");
        //}

        // 测试 ViewModel 强类型视图  对应的是（实现ViewModel）
        //public ActionResult GetView()
        //{
        //    Employee emp = new Employee() { FirstName = "Sukesh", LastName = "Marla", Salary = 20000 };

        //    EmployeeViewModel vmEmp = new EmployeeViewModel() { EmployeeName = emp.FirstName + " " + emp.LastName, Salary = emp.Salary.ToString("C") };
        //    if (emp.Salary > 15000)
        //        vmEmp.SalaryColor = "yellow";
        //    else
        //        vmEmp.SalaryColor = "green";

        //    vmEmp.UserName = "Admin";

        //    return View("MyView",vmEmp);
        //}

        public ActionResult GetView()
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
            lvmEmp.UserName = "Admin";

            return View("MyView", lvmEmp);
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

    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "johnson";
            emp.LastName = " fernandes";
            emp.Salary = 14000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "michael";
            emp.LastName = "jackson";
            emp.Salary = 16000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "robert";
            emp.LastName = " pattinson";
            emp.Salary = 20000;
            employees.Add(emp);

            return employees;
        }
    }
}