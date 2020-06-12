using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblGuide
    {
        public TblGuide()
        {
            TblPackage = new HashSet<TblPackage>();
        }

        public int GuideId { get; set; }
        public string GuideName { get; set; }
        public string GuideGender { get; set; }
        public int? GuideCityId { get; set; }
        public string GuideContact { get; set; }
        public decimal? GuideFees { get; set; }
        public bool? GuideStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblCity GuideCity { get; set; }
        public virtual ICollection<TblPackage> TblPackage { get; set; }
    }
}
