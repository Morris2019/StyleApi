using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class PasswordReset
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
