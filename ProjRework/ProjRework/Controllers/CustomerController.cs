using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjRework.DataAccess.Repositories;
using ProjRework.Logic.Entities;
using ProjRework.Logic.Interfaces;

namespace ProjRework.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {

    public CustomerRepository Repo { get; }

    public CustomerController(ICustomerRepository repo)
    {
      Repo = (CustomerRepository)(repo ?? throw new ArgumentNullException(nameof(repo)));
    }

    // GET: api/<CustomerController>
    [HttpGet]
    public IEnumerable<CustomerEntity> Get()
    {
      //Make a call to the get method of the repository. Returns a list of customers
      var customers = Repo.Get();
      return customers;
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public CustomerEntity Get(int id)
    {
      var customer = Repo.Get(id);
      return (CustomerEntity)customer;
    }

    // POST api/<CustomerController>
    [HttpPost]
    public void Post( string first, string last)
    {
      var newCust = new CustomerEntity
      {
        FirstName = first,
        LastName = last
      };
      Repo.Insert(newCust);
    }

    // PUT api/<CustomerController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, string value)
    //{
    //}

    //// DELETE api/<CustomerController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //  Repo.Delete(id);
    //}
  }
}
