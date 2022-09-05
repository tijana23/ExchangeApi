using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class Users
    {
        public Users()
        {
            Operations = new HashSet<Operations>();
        }

        public int UsersId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Operations> Operations { get; set; }
    }
}
