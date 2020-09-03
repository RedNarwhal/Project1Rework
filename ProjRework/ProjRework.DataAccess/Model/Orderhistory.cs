using System;
using System.Collections.Generic;

namespace ProjRework.DataAccess.Model
{
    public partial class Orderhistory
    {
        public int Orderhistoryid { get; set; }
        public int Orderid { get; set; }
        public int Productid { get; set; }

        public virtual Orderinst Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
