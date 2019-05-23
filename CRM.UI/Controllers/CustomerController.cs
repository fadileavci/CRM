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
    public class CustomerController : Controller
    {
		CustomerBLL customerbll = new CustomerBLL();
		NotBLL notebll = new NotBLL();
		LeadBLL leadbll = new LeadBLL();
		// GET: Customer

		[MyAuthenticationFilter]
		public ActionResult Index()
        {
			Employee emp = Session["Login"] as Employee;
			foreach (EmployeeRole item in emp.EmployeeRoles)
			{
				if (item.Role.RoleName == "Admin")
				{

					ViewBag.Delete = "visible";
				}
				else if (item.Role.RoleName == "Manager")
				{
					ViewBag.Delete = "visible";
				}
				else
					ViewBag.Delete = "hidden";
			
			}
			List<Customer> customer = customerbll.GetCustomers();
			return View(customer);


		}

		public ActionResult AddCustomer()
		{			
			return View();
		}
		[HttpPost]
		public ActionResult AddCustomer(Customer custo)
		{
		
			customerbll.AddCustomer(custo);
			return RedirectToAction("Index");
		}
		public ActionResult DeleteCustomer(int id)
		{
		Customer cus=customerbll.GetCustomer(id);
			customerbll.DeleteCustomer(cus);
			return RedirectToAction("Index");

		}
		[MyAuthenticationFilter]
		public ActionResult UpdateCustomer(int id)
		{
		  Customer cus=	customerbll.GetCustomer(id);
		return View(cus);
		}

		[HttpPost]
		public ActionResult UpdateCustomer(Customer custo)
		{
			Customer cus = customerbll.GetCustomer(custo.CustomerID);
			cus.CustomerID = custo.CustomerID;
			cus.Address = custo.Address;
			cus.BirthDate = custo.BirthDate;
			cus.City = custo.City;
			cus.Company = custo.Company;
			cus.Email = custo.Email;
			cus.Name = custo.Name;
			cus.Surname = custo.Surname;
			cus.Phone = custo.Phone;
			customerbll.UpdateCustomer(cus);
			return RedirectToAction("Index");

		}
		public ActionResult Not()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Not(Note not)//not ekleme
		{
			Employee emp = Session["Login"] as Employee;
			Customer cust = Session["Customer"] as Customer;
			not.EmployeeID = emp.EmployeeID;
			not.CustomerID = cust.CustomerID;
			not.Date = DateTime.Now;
			notebll.AddNote(not);
			return RedirectToAction("Index");
		}

		[MyAuthenticationFilter]
		public ActionResult Nots(int id)//not listeleme
		{
			Customer cust = customerbll.GetCustomer(id);
			List<Note> notlar = notebll.NotList(cust.CustomerID);
			Session["Customer"] = cust;
			return View(notlar);
		}
		[MyAuthenticationFilter]
		public ActionResult DeleteNot(int id)//Not silme
		{
			Note not = notebll.GetNot(id);
			notebll.DeleteNot(not);
			return RedirectToAction("Index");
		}

		public ActionResult Lead()//lead ekleme
		{
			return View();
		}
		[HttpPost]
		public ActionResult Lead(Lead lead)//lead ekleme post metodu
		{
			Employee emp = Session["Login"] as Employee;
			Customer cus = Session["Customer"] as Customer;
			lead.EmployeeID = emp.EmployeeID;
			lead.CustomerID = cus.CustomerID;
			lead.Date = DateTime.Now;
			leadbll.AddLead(lead);
			return RedirectToAction("Index");
 
		}
		public ActionResult Leads(int id)//lead listemele
		{
			Customer cust = customerbll.GetCustomer(id);
			List<Lead> leadlar = leadbll.LeadList(id);
			Session["Customer"] = cust;
			return View(leadlar);
		}
		[MyAuthenticationFilter]
		public ActionResult DeleteLead(int id)// lead silme
		{
			Lead lead = leadbll.GetLead(id);
			leadbll.DeleteLead(lead);
			return RedirectToAction("Index");
		}


	




	}
}