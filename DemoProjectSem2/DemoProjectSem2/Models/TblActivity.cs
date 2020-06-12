using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblActivity
    {
        public TblActivity()
        {
            TblPackageActivities = new HashSet<TblPackageActivities>();
        }

        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public TimeSpan? ActivityTiming { get; set; }
        public decimal? ActivityCost { get; set; }
        public int? ActivityType { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblActivityType ActivityTypeNavigation { get; set; }
        public virtual ICollection<TblPackageActivities> TblPackageActivities { get; set; }
    }
}
