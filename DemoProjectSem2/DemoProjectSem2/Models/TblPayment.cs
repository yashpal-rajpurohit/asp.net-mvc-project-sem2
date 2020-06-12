using System;
using System.Collections.Generic;

namespace DemoProjectSem2.Models
{
    public partial class TblPayment
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public decimal? PaymentAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? UserId { get; set; }
        public string PaymentTransactionId { get; set; }

        public virtual TblUser User { get; set; }
    }
}
