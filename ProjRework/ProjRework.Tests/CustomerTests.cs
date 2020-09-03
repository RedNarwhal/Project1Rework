using ProjRework.Logic.Entities;
using System;
using Xunit;

namespace ProjRework.Tests
{
  public class CustomerTests
  {
    [Theory]
    [InlineData("John", "Doe")]
    public void CustomerEntityCanBeCreated(string first, string last)
    {
      //ARRANGE
      var newcust = new CustomerEntity
      {
        FirstName = first,
        LastName = last
      };
      //ACT
      //ASSERT
      Assert.Equal(first, newcust.FirstName);
      Assert.Equal(last, newcust.LastName);
    }

  }
}
