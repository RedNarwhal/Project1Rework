using ProjRework.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Entities
{
  public class ProductEntity : IProduct
  {
    public int ProductId { get; }

    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }

    public ProductEntity(int id)
    {
      ProductId = id;
    }
    public ProductEntity(string desc, decimal price)
    {
      ProductDescription = desc;
      ProductPrice = price;
    }
  }
}
