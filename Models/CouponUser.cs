using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class CouponUser
    {
        public long Id { get; set; }
        public long? CouponId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual User User { get; set; }
    }
}
