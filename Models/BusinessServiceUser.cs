using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class BusinessServiceUser
    {
        public int BusinessServiceId { get; set; }
        public int UserId { get; set; }

        public virtual BusinessService BusinessService { get; set; }
        public virtual User User { get; set; }
    }
}
