using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
	public class NotBLL
	{

		RepositoryPattern<Note> repo = new RepositoryPattern<Note>();

		public List<Note> NotList(int id)
		{
			return repo.List(x=> x.CustomerID==id);
		}
		public void AddNote(Note not)
		{
			repo.Add(not);
			
		}
		public void DeleteNot(Note not)
		{
			repo.Delete(not);

		}
		public Note GetNot(int id)
		{
			return repo.Find(x => x.NoteID == id);
		}


	}
}
