using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
	public class LeadBLL
	{
		RepositoryPattern<Lead> repo = new RepositoryPattern<Lead>();

		public List<Lead> LeadList(int id)
		{
			return repo.List(x=> x.CustomerID== id);
		}

		public void AddLead(Lead lead)
		{
			repo.Add(lead);
		}

		public void DeleteLead(Lead lead)
		{
			repo.Delete(lead);
		}
		public Lead GetLead(int id)
		{
			return repo.Find(x=>x.LeadID==id);
		}


	}
}
