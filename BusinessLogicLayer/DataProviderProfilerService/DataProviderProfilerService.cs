using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DataProviderProfilerService
{
    public class DataProviderProfilerService : IDataProviderProfilerService
    {
        private readonly IApplicationDbContext _dbContext;
     public DataProviderProfilerService(IApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void ComparePerformance()
        {
            var employes = _dbContext.Employes.Include(e => e.HiringHistories);

            
        }
    }
}
