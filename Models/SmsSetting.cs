using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class SmsSetting
    {
        public long Id { get; set; }
        public string NexmoStatus { get; set; }
        public string NexmoKey { get; set; }
        public string NexmoSecret { get; set; }
        public string NexmoFrom { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
