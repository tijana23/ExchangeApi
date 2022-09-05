using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class Operations
    {
        public int OperationId { get; set; }
        public int? OperationTypeId { get; set; }
        public int? UserId { get; set; }
        public DateTime? OperationDate { get; set; }
        public int? Amount { get; set; }
        public int? CurrencyFrom { get; set; }
        public int? CurrencyTo { get; set; }

        public virtual ClsCurrency CurrencyFromNavigation { get; set; }
        public virtual ClsCurrency CurrencyToNavigation { get; set; }
        public virtual ClsOperationType OperationType { get; set; }
        public virtual Users User { get; set; }
    }
}
