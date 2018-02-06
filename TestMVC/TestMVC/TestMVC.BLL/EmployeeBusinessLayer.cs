using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC.Models;
using TestMVC.DAL;

namespace TestMVC.TestMVC.BLL
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Database.CreateIfNotExists();

            return salesDal.Employees.ToList();
        }
    }
}