using ProjRework.Logic.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Interfaces
{
  public interface ICustomerRepository
  {
    IEnumerable<CustomerEntity> Get();
    CustomerEntity Get(int id);
    //void Insert(T obj);
    void Delete(int id);
    void Update();
    void Save();
  }
}

