using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PublicDataService
{
   public interface IPublicDataService
    {
        List<PublicData> GetPublicData();
    }
}
