using ProjRework.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Interfaces
{
  interface IProductRepository
  {
    //Get
    public IEnumerable<ProductEntity> Get();
    //GetById(int id)
    public ProductEntity Get(int id);
    //Insert
    //Delete
  }
}
