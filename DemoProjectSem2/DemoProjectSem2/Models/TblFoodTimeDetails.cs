using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblFoodTimeDetails
    {
        public TblFoodTimeDetails()
        {
            TblHotel = new HashSet<TblHotel>();
        }

        public int FoodTimeId { get; set; }
        public string FoodTimeName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

        public virtual ICollection<TblHotel> TblHotel { get; set; }
    }
}
