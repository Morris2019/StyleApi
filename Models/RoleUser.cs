using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class RoleUser
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }

        public virtual Role Role { get; set; }
    }
}
