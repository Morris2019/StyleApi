using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class Role
    {
        public Role()
        {
            PermissionRoles = new HashSet<PermissionRole>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
