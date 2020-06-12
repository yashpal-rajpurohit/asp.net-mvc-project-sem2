using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblPackageActivities
    {
        public int PackageActivitiesId { get; set; }
        public int? PackageId { get; set; }
        public int? ActivityId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblActivity Activity { get; set; }
        public virtual TblPackage Package { get; set; }
    }
}
