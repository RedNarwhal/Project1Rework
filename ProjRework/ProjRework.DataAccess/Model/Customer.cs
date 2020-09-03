using System;
using System.Collections.Generic;

namespace ProjRework.DataAccess.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Orderinst = new HashSet<Orderinst>();
        }

        public int Custid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Orderinst> Orderinst { get; set; }
    }
}
