using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataProviderProfilerService
{
  public interface IDataProviderProfilerService
    {
        public LeadTime ComparePerformance();
    }
}
