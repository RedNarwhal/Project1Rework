using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Interfaces
{
  interface IProduct
  {
    public int ProductId { get; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    
  }
}
