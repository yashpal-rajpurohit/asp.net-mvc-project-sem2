using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPackage = new HashSet<TblPackage>();
            TblPayment = new HashSet<TblPayment>();
            TblUserPackage = new HashSet<TblUserPackage>();
        }

        public int UserId { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public DateTime? UserDob { get; set; }
        public string UserGender { get; set; }
        public int? UserCityId { get; set; }
        public string UserPassword { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblCity UserCity { get; set; }
        public virtual ICollection<TblPackage> TblPackage { get; set; }
        public virtual ICollection<TblPayment> TblPayment { get; set; }
        public virtual ICollection<TblUserPackage> TblUserPackage { get; set; }
    }
}
