using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblState
    {
        public TblState()
        {
            TblCity = new HashSet<TblCity>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual ICollection<TblCity> TblCity { get; set; }
    }
}
