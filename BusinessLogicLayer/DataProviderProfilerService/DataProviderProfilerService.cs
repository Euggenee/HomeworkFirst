using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DataProviderProfilerService
{
    public class DataProviderProfilerService : IDataProviderProfilerService
    {
        private readonly IApplicationDbContext _dbContext;
        DataProviderProfilerService(IApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void ComparePerformance()
        {
         
        }
    }
}
