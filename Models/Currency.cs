using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class Currency
    {
        public Currency()
        {
            CompanySettings = new HashSet<CompanySetting>();
        }

        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<CompanySetting> CompanySettings { get; set; }
    }
}
