using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class ClsCurrency
    {
        public ClsCurrency()
        {
            ExchangeRatesCurrencyFromNavigation = new HashSet<ExchangeRates>();
            ExchangeRatesCurrencyToNavigation = new HashSet<ExchangeRates>();
            OfficialRates = new HashSet<OfficialRates>();
            OperationsCurrencyFromNavigation = new HashSet<Operations>();
            OperationsCurrencyToNavigation = new HashSet<Operations>();
        }

        public int CurrencyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }

        public virtual ICollection<ExchangeRates> ExchangeRatesCurrencyFromNavigation { get; set; }
        public virtual ICollection<ExchangeRates> ExchangeRatesCurrencyToNavigation { get; set; }
        public virtual ICollection<OfficialRates> OfficialRates { get; set; }
        public virtual ICollection<Operations> OperationsCurrencyFromNavigation { get; set; }
        public virtual ICollection<Operations> OperationsCurrencyToNavigation { get; set; }
    }
}
