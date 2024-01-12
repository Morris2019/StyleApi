using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class FrontThemeSetting
    {
        public int Id { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string CustomCss { get; set; }
        public string Logo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
