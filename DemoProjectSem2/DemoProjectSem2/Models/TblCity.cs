using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblGuide = new HashSet<TblGuide>();
            TblHotel = new HashSet<TblHotel>();
            TblPackage = new HashSet<TblPackage>();
            TblUser = new HashSet<TblUser>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblState State { get; set; }
        public virtual ICollection<TblGuide> TblGuide { get; set; }
        public virtual ICollection<TblHotel> TblHotel { get; set; }
        public virtual ICollection<TblPackage> TblPackage { get; set; }
        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
