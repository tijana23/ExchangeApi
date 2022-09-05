using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class Loan
    {
        public int LoanInfoId { get; set; }
        public double? Payment { get; set; }
        public double? Capital { get; set; }
        public double? Interest { get; set; }
        public double? Balance { get; set; }
    }
}
