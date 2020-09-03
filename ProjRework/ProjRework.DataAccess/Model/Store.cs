using System;
using System.Collections.Generic;

namespace ProjRework.DataAccess.Model
{
    public partial class Store
    {
        public Store()
        {
            Orderinst = new HashSet<Orderinst>();
            Storeinventory = new HashSet<Storeinventory>();
        }

        public int Storeid { get; set; }
        public string Storename { get; set; }

        public virtual ICollection<Orderinst> Orderinst { get; set; }
        public virtual ICollection<Storeinventory> Storeinventory { get; set; }
    }
}
