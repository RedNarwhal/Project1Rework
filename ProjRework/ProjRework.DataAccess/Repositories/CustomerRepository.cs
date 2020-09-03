using System;
using System.Collections.Generic;
using ProjRework.DataAccess.Model;
using System.Linq;
using ProjRework.Logic.Interfaces;
using System.Collections;
using ProjRework.Logic.Entities;

namespace ProjRework.DataAccess.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {

    private readonly ProjReworkContext context;

    public CustomerRepository(ProjReworkContext context)
    {
      this.context = context;
    }

    public IEnumerable<CustomerEntity> Get()
    {
      // before it is returned, the Customer needs to be changed into the object version
      var query = context.Customer.ToList();
      var customers = new List<CustomerEntity>();
      foreach (var item in query)
      {
        customers.Add(new CustomerEntity
        {
          Id = item.Custid,
          FirstName = item.Firstname,
          LastName = item.Lastname
        });
      }
      return customers;
    }

    // Will throw an exception if an id that is not in the database is sent
    public CustomerEntity Get(int id)
    {
      var query = context.Customer.Find(id);
      var customer = new CustomerEntity
      {
        Id = query.Custid,
        FirstName = query.Firstname,
        LastName = query.Lastname
      };
      return customer;
    }

    public void Insert(CustomerEntity obj)
    {
      var e = new Customer
      {
        Firstname = obj.FirstName,
        Lastname = obj.LastName
      };
      context.Add(e);
      Save();
    }
    public void Update()
    {
      throw new NotImplementedException();
    }
    public void Delete(int id)
    {
      var customer = Get(id);
      context.Customer.Remove(ConvertToCustomer(customer));
      Save();
    }

    public void Save()
    {
      context.SaveChanges();
    }

    //Convert between Customer and Customer entity and vice-versa
    private Customer ConvertToCustomer(CustomerEntity obj)
    {
      return new Customer
      {
        Custid = obj.CustomerId,
        Firstname = obj.FirstName,
        Lastname = obj.LastName
      };
    }
  }
}
