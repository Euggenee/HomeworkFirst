﻿using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
   public interface IApplicationDbContext
    {
        public DbSet<PublicData> PublicDatas { get; set; }
        public DbSet<PrivateData> PrivateDatas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ApiRequestsLog> ApiRequestsLogs { get; set; }
        public int SaveChanges();

    }
}
