using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblPackage
    {
        public TblPackage()
        {
            TblPackageActivities = new HashSet<TblPackageActivities>();
            TblUserPackage = new HashSet<TblUserPackage>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDetail { get; set; }
        public string PackageImage { get; set; }
        public int? PackageNoOfDays { get; set; }
        public int? PackageNoOfNights { get; set; }
        public int? PackageHotelId { get; set; }
        public int? PackageGuideId { get; set; }
        public int? PackageCityId { get; set; }
        public decimal? PackageTotalCost { get; set; }
        public bool? PackageStatus { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblCity PackageCity { get; set; }
        public virtual TblGuide PackageGuide { get; set; }
        public virtual TblHotel PackageHotel { get; set; }
        public virtual TblUser User { get; set; }
        public virtual ICollection<TblPackageActivities> TblPackageActivities { get; set; }
        public virtual ICollection<TblUserPackage> TblUserPackage { get; set; }
    }
}
