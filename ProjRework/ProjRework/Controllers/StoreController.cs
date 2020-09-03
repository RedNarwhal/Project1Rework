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
  public class StoreController : ControllerBase
  {
    public StoreRepository Repo { get; }
    // GET: api/<StoreController>
    public StoreController(IStoreRepository repo)
    {
      Repo = (StoreRepository)(repo ?? throw new ArgumentNullException(nameof(repo)));
    }
    [HttpGet]
    public List<string> Get()
    {
      var stores = Repo.Get();
      return stores;
    }

    // GET api/<StoreController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      var store = Repo.Get(id);
      return store.StoreName;
    }

    // POST api/<StoreController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<StoreController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}
    
  }
}
