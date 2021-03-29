﻿using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public override int SaveChanges() //  перегрузили(переопределили)
        {
            return base.SaveChanges();
        }

        public DbSet<PublicData> PublicDatas { get; set; }
        public DbSet<PrivateData> PrivateDatas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ApiRequestsLog> ApiRequestsLogs { get; set; }
    }
}
