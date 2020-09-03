using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Interfaces
{
  interface ICustomer
  {
    public int CustomerId { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
