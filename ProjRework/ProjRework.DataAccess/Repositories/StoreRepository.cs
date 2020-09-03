using ProjRework.DataAccess.Model;
using ProjRework.Logic.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjRework.Logic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjRework.DataAccess.Repositories
{
  public class StoreRepository : IStoreRepository
  {

    public readonly ProjReworkContext context;
    
    public StoreRepository(ProjReworkContext context)
    {
      this.context = context;
    }

    public List<string> Get()
    {
      var query = context.Store.ToList();
      var stores = new List<string>();
      foreach(var item in query)
      {
        stores.Add(item.Storename);
      }
      return stores;
    }
    public StoreEntity Get(int id)
    {
      var query = context.Store.Find(id);
      return (new StoreEntity(query.Storeid)
      {
        StoreName = query.Storename,
        Inventory = GetStoreInventory(id)
      });
    }
    public void Update()
    {
      throw new NotImplementedException();
    }
    public void Save()
    {
      context.SaveChanges();
    }

    // Get Store Inventory
    private Dictionary<ProductEntity, double> GetStoreInventory(int storeId)
    {
      var invQuery = context.Storeinventory
          .Include(i => i.Store)
          .Where(i => i.Storeid == storeId);

      var inv = new Dictionary<ProductEntity, double>();
      foreach(var item in invQuery)
      {
        var prod = new ProductEntity(item.Productid)
        {
          ProductDescription = item.Product.Productdescription,
          ProductPrice = (decimal)item.Product.Productprice
        };
        inv.Add(prod, item.Quantity);
      }
      return inv;
    }
  }
}
