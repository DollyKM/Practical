using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeDetailModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiHttpClient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<EmployeeDetailModel>>().Result;
            return View(empList);
        }

        // GET: Employee
        //public ActionResult Index(IQueryable searchName)
        //{
        //    IQueryable<EmployeeDetailModel> empList;
        //    HttpResponseMessage response = GlobalVariables.webApiHttpClient.GetAsync("Employee").Result;
        //    empList = response.Content.ReadAsAsync<IQueryable<EmployeeDetailModel>>().Contains(searchName);
        //    return View(empList);
        //}

        public ActionResult Add(int id=0)
        {
            if (id == 0) 
            return View(new EmployeeDetailModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiHttpClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeDetailModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Add(EmployeeDetailModel emp)
        {
            if (emp.EmpID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiHttpClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully!";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiHttpClient.PutAsJsonAsync("Employee/"+emp.EmpID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully!";

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiHttpClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}