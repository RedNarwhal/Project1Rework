using System;
using System.Collections.Generic;
using System.Text;

namespace ProjRework.Logic.Interfaces
{
  interface IStore
  {
    public int StoreId { get; }
    public string StoreName { get; set; }
  }
}
