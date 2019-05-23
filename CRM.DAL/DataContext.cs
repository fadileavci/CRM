namespace CRM.DAL
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using CRM.Entity;

	public partial class DataContext : DbContext
	{
		public DataContext()
			: base("name=DataContext")
		{
		}

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Email> Emails { get; set; }
		public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Lead> Leads { get; set; }
		public virtual DbSet<Note> Notes { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
				.HasMany(e => e.Emails)
				.WithRequired(e => e.Customer)
				.HasForeignKey(e => e.EmailTo)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Employee>()
				.HasMany(e => e.EmployeeRoles)
				.WithRequired(e => e.Employee)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Role>()
				.HasMany(e => e.EmployeeRoles)
				.WithRequired(e => e.Role)
				.WillCascadeOnDelete(false);
		}
	}
}
