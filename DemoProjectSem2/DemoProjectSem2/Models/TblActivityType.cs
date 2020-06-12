using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblActivityType
    {
        public TblActivityType()
        {
            TblActivity = new HashSet<TblActivity>();
        }

        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual ICollection<TblActivity> TblActivity { get; set; }
    }
}
