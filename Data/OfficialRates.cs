using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class OfficialRates
    {
        public int OfficialRatesId { get; set; }
        public DateTime? ValidityDate { get; set; }
        public int? Currency { get; set; }
        public double? Rate { get; set; }
        public int? IsActive { get; set; }

        public virtual ClsCurrency CurrencyNavigation { get; set; }
    }
}
