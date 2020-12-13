using AT.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Data.Context
{
    public class ATContext : DbContext
    {
        public ATContext(DbContextOptions<ATContext> options) : base(options)
        {
        }

        public virtual DbSet<InsuredUser> InsuredUser { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<District> District { get; set; }
    }
}
