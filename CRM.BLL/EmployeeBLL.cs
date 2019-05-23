using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
	public class EmployeeBLL
	{
		RepositoryPattern<Employee> repo = new RepositoryPattern<Employee>();

		public Employee GetEmployee(string mail)
		{
			return repo.Find(x => x.Email == mail );
		}

		public List<Employee> GetEmployees()
		{
			return repo.List();
		}
		
	}
}
