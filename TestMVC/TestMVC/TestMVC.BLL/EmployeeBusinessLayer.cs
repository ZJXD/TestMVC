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
        readonly SalesERPDAL salesDal = new SalesERPDAL();

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            //salesDal.Database.CreateIfNotExists();

            return salesDal.Employees.ToList();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Employee SaveEmployee(Employee e)
        {
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}