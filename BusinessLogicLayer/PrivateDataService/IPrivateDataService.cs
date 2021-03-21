using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PrivateDataService
{
  public interface IPrivateDataService
    {
       List<PrivateData> GetPrivateData();
    }
}
