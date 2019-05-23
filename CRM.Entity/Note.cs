namespace CRM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Note
    {
        public int NoteID { get; set; }

        public int? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string NoteDetail { get; set; }

        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
