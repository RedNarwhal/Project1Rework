using System;
using System.Collections.Generic;

namespace ProjRework.DataAccess.Model
{
    public partial class Product
    {
        public Product()
        {
            Orderhistory = new HashSet<Orderhistory>();
            Storeinventory = new HashSet<Storeinventory>();
        }

        public int Productid { get; set; }
        public string Productdescription { get; set; }
        public decimal? Productprice { get; set; }

        public virtual ICollection<Orderhistory> Orderhistory { get; set; }
        public virtual ICollection<Storeinventory> Storeinventory { get; set; }
    }
}
