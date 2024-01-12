﻿using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class EmployeeGroup
    {
        public EmployeeGroup()
        {
            EmployeeGroupServices = new HashSet<EmployeeGroupService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<EmployeeGroupService> EmployeeGroupServices { get; set; }
    }
}
