using ProjRework.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Entities
{
  public class StoreEntity : IStore
  {
    public int StoreId { get; }

    public string StoreName { get; set; }

    // Inventory as Dictionary of Products
    public Dictionary<ProductEntity, double> Inventory { get; set; }
    
    public StoreEntity()
    {

    }
    public StoreEntity(int storeid)
    {
      StoreId = storeid;
    }
    public StoreEntity(string name)
    {
      StoreName = name;
    }

    //ProcessTransaction
    //check stock in inventory. decrement stock in inventory. update database to reflect order.
  }
}
