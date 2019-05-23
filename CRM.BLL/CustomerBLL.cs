using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
	public class CustomerBLL
	{
		RepositoryPattern<Customer> repo = new RepositoryPattern<Customer>();

		public  List<Customer> GetCustomers()
		{
			return repo.List();		
		}
		public Customer GetCustomer(int Id)
		{
			return repo.Find(x=>x.CustomerID==Id);
		}

		public void AddCustomer(Customer cus)
		{
			repo.Add(cus);
		
		}
		public void UpdateCustomer(Customer cus)
		{
			repo.Update(cus);

		}
		public void DeleteCustomer(Customer cus)
		{
			repo.Delete(cus);
			
		}


	}
}
