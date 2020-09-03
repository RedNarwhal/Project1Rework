using System;
using System.Collections.Generic;

namespace ProjRework.DataAccess.Model
{
    public partial class Orderinst
    {
        public Orderinst()
        {
            Orderhistory = new HashSet<Orderhistory>();
        }

        public int Orderid { get; set; }
        public DateTime? Orderdate { get; set; }
        public int Customerid { get; set; }
        public int Storeid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Orderhistory> Orderhistory { get; set; }
    }
}
