using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblUserPackage
    {
        public int UserPackageId { get; set; }
        public int? UserId { get; set; }
        public int? PackageId { get; set; }
        public DateTime? PackageDateFrom { get; set; }
        public DateTime? PackageDateTo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblPackage Package { get; set; }
        public virtual TblUser User { get; set; }
    }
}
