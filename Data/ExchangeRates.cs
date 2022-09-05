using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class ExchangeRates
    {
        public int ExchangeRatesId { get; set; }
        public DateTime? ValidityDate { get; set; }
        public int? CurrencyFrom { get; set; }
        public int? CurrencyTo { get; set; }
        public double? Rate { get; set; }
        public int? IsActive { get; set; }

        public virtual ClsCurrency CurrencyFromNavigation { get; set; }
        public virtual ClsCurrency CurrencyToNavigation { get; set; }
    }
}
