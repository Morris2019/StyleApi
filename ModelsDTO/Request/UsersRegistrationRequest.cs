using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanStyleApi.ModelsDTO.Request
{
    public class UsersRegistrationRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Required]
        public int MobileVerified { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
