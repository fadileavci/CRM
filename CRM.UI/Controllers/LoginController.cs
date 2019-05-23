using CRM.BLL;
using CRM.Entity;
using CRM.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class LoginController : Controller
    {


		EmployeeBLL employeebll = new EmployeeBLL();

		public ActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Index(Employee employee)
		{
			Employee emp = employeebll.GetEmployee(employee.Email);
			if (emp.Password==employee.Password)
			{
				Session["Login"] = emp;
				return RedirectToAction("Index","Customer");
			}
			else
			{
				return RedirectToAction("LoginHata");
			}

		}
		[MyAuthenticationFilter]
		public ActionResult Logout()
		{
			Session["Login"] = null;
			return RedirectToAction("Index");
		}
		public ActionResult LoginHata()
		{
			return View();
		}

    }
}