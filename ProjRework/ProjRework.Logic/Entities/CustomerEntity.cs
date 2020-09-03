using ProjRework.Logic.Interfaces;
using System;

namespace ProjRework.Logic.Entities
{
  public class CustomerEntity : ICustomer
  {
    public int CustomerId { get; }

    // Put validation on First and Last Name property's setter to ensure a valid name is entered
    public int Id { get; set; }
    public string FirstName 
    { 
      get 
      {
        return FirstName;
      } 
      set
      {// Server side validation for name strings
        if (value.Length < 1) 
        {
          FirstName = value;
        }
        else
        {
          throw new ArgumentException();
        }
      }
    }
    public string LastName
    {
      get
      {
        return LastName;
      }
      set
      {// Server side validation for name strings
        if (value.Length < 1)
        {
          LastName = value;
        }
        else
        {
          throw new ArgumentException();
        }
      }
    }

    //Zero-arg constructor for Customer
    public CustomerEntity()
    {
    } 
    public CustomerEntity(string first, string last)
    {
      FirstName = first;
      LastName = last;
    }

    public CustomerEntity(int id, string first, string last)
    {
      Id = id;
      FirstName = first;
      LastName = last;
    }
  }
}
