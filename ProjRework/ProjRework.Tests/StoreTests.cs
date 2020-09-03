using ProjRework.Logic.Entities;
using System;
using Xunit;

namespace ProjRework.Tests
{
  public class StoreTests
  {
    [Theory]
    [InlineData("Barry's Bargins")]
    public void StoresCanBeCreated(string name)
    {
      var newstore = new StoreEntity
      {
        StoreName = name
      };
      Assert.Equal(name, newstore.StoreName);
    }
  }
}
