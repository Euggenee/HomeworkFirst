﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BusinessLogicLayer.Models;
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
        public LeadTime ComparePerformance()
        {
             Stopwatch linqMethodLeadTime = new Stopwatch();
       
            linqMethodLeadTime.Start();
            var employesLinq = _dbContext.Employes.Include(e => e.HiringHistoris).ThenInclude(a => a.Achievements).ToList();
            linqMethodLeadTime.Stop();
            long LinqMethodLeadTime = linqMethodLeadTime.ElapsedMilliseconds;

            Stopwatch rawSQLQueryLeadTime = new Stopwatch();
            rawSQLQueryLeadTime.Start();
            var emploeSql = _dbContext.Employes.FromSqlRaw("SELECT * FROM Employes").ToList();
            rawSQLQueryLeadTime.Stop();
            long RawSQLQueryLeadTime = rawSQLQueryLeadTime.ElapsedMilliseconds;

            return new LeadTime { LinqMethodLeadTime = LinqMethodLeadTime, RawSQLQueryLeadTime = RawSQLQueryLeadTime };
        }
    }
}