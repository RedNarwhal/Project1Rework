using ProjRework.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Interfaces
{
  public interface IStoreRepository
  {
    List<string> Get();
    StoreEntity Get(int id);
    //void Insert();
    void Update();
    void Save();
  }
}
