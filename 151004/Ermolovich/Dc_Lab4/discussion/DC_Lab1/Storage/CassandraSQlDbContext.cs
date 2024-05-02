﻿using DC_Lab1.DB.BaseDBContext;
using Microsoft.EntityFrameworkCore;

namespace DC_Lab1.DB
{
    public class CassandraSQlDbContext : BaseContext
    {
        public CassandraSQlDbContext()
        {
        }

        public CassandraSQlDbContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=distcomp;Username=postgres;Password=postgres");
    }
}
