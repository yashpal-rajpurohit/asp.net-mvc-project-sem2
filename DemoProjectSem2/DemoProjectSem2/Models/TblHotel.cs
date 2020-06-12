using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblHotel
    {
        public TblHotel()
        {
            TblPackage = new HashSet<TblPackage>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int? CityId { get; set; }
        public int? FoodTimeId { get; set; }
        public decimal? HotelCost { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblFoodTimeDetails FoodTime { get; set; }
        public virtual ICollection<TblPackage> TblPackage { get; set; }
    }
}
