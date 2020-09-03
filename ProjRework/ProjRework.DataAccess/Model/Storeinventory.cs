using System;
using System.Collections.Generic;

namespace ProjRework.DataAccess.Model
{
    public partial class Storeinventory
    {
        public int Storeinvid { get; set; }
        public int Storeid { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
